using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Framework
{

    //public class KeyValue
    //{
    //    public string Key { get; set; }
    //    public object Value { get; set; }
    //}

    public class ClassUtils
    {
        //DisplayAttribute
        //public static string GetAttribute<Attribute>(Type objecttype , Attribute attribute, string propertyname) where Attribute : class
        //{

        //    var properties = objecttype.GetProperties()
        //        .Where(p => p.IsDefined(attribute.GetType(), false) &&  p.PropertyType.Name == propertyname)
        //        .Select(p => new
        //        {
        //            //PropertyName = p.Name,
        //            p.GetCustomAttributes(attribute.GetType(),
        //                    false).Cast<DisplayAttribute>().Single().Name
        //        });

        //    return properties.Select(x=>x.Name).FirstOrDefault();
        //}

        public static string GetColumnAttributeValue(object objecttype,string propertyName)
        {
            var proinfo = objecttype.GetType().GetProperties().Where(x => x.Name == propertyName).FirstOrDefault();

            //foreach (PropertyInfo property in objecttype.GetType().GetProperties())
            //{
                var attribute = Attribute.GetCustomAttribute(proinfo, typeof(ColumnAttribute))
                    as ColumnAttribute;

                if (attribute != null) // This property has a KeyAttribute
                {
                // Do something, to read from the property:
                    return attribute.Name; //.GetValue(objecttype);
                    
                }
            //}

            return null;
        }


        public static object GetKeyAttributeValue(object objecttype) 
        {

            foreach (PropertyInfo property in objecttype.GetType().GetProperties())
            {
                var attribute = Attribute.GetCustomAttribute(property, typeof(KeyAttribute))
                    as KeyAttribute;

                if (attribute != null) // This property has a KeyAttribute
                {
                    // Do something, to read from the property:
                    object val = property.GetValue(objecttype);
                    return val;
                }
            }

            return null; 
        }

        public static bool IsPropertyNulleable(Type prop)
        {
            if (Nullable.GetUnderlyingType(prop) != null)
            {
                // It's nullable
                return true;
            }

            return false;
        }

        public static object GetPropertyValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        public static Dictionary<string,int> DicGetProperties(object mlist)
        {

            //if (mlist == null)
            //    return null;

            var item = mlist;

            if (item == null)
                return null;

            Type typeOfMyObject = item.GetType();
            PropertyInfo[] properties = typeOfMyObject.GetProperties();
            var names = new Dictionary<string,int>();
            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].PropertyType.ToString().Contains("ExtensionDataObject"))
                    continue;

                names.Add(properties[i].Name, getProperty(properties[i].PropertyType.ToString()));
            }

            return names;

        }

        static int getProperty(string name)
        {
            if (name.Contains("String"))
                return 8;

            if (name.Contains("Boolean"))
                return 11;

            if (name.Contains("Date"))
                return 7;

            if (name.Contains("Byte"))
                return 5;

            return 8;
        }

        //public static List<string> GetProperties(IList objectproperties)
        //{
        //    var lista = objectproperties;
        //    object uniqueobject = null;
        //    foreach (var mObject in lista)
        //    {
        //        uniqueobject = mObject;
        //        break;
        //    }



        //    //Type myType = uniqueobject.GetType();

        //    var result = new List<string>();

        //    PropertyInfo[] properties = uniqueobject.GetType().GetProperties();
        //    foreach (PropertyInfo property in properties)
        //    {
        //        result.Add(property.Name);


        //        //if (property.Name == "MyProperty")
        //        //{
        //        //    object value = results.GetType().GetProperty(property.Name).GetValue(uniqueobject, null);
        //        //    if (value != null)
        //        //    {
        //        //        //assign the value
        //        //    }
        //        //}
        //    }

        //    //IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

        //    //foreach (PropertyInfo prop in props)
        //    //{
        //    //    object propValue = prop.GetValue(uniqueobject, null);

        //    //    // Do something with propValue
        //    //}

        //    return result;

        //}


        public static Dictionary<string, object> GetPropertiesValue<T>(object obj)
        {
           
            var result = new Dictionary<string, object>();

            PropertyInfo[] properties = ((T)(obj)).GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(obj, null);
                string key = property.Name;

                if (property.PropertyType.FullName.Contains("ReadOnlyCollection")) 
                    continue;
                if (property.PropertyType.FullName.Contains("ICollection"))
                    continue;

                //if (property.PropertyType.IsClass)
                //    continue;

                //if (typeof(IReadOnlyCollection<>).IsAssignableFrom(property.PropertyType))
                //    continue;

                //if (typeof(ReadOnlyCollection<>).IsAssignableFrom(property.PropertyType))
                //    continue;

                //if (typeof(ICollection<>).IsAssignableFrom(property.PropertyType))
                //    continue;

                result.Add(key, value);
               
            }


            return result;

        }

        public static void SetValue(object entity,string propertyname, object value)
        {
            //PropertyInfo propertyInfo = entity.GetType().GetProperty(propertyname);


            var property = entity.GetType().GetProperty(propertyname);
            if (property != null)
            {
                Type t = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

                object safeValue = null;

                if (value != null)
                    if (value.ToString().Trim() == "")
                    {
                        if (t.GetType() == typeof(Int32))
                            safeValue = 0;
                    }
                    else                     
                        safeValue = Convert.ChangeType(value, t);

                property.SetValue(entity, safeValue, null);
            }

            
            
        }

        public static bool Compare<T>(T Object1, T object2)
        {
            //Get the type of the object
            Type type = typeof(T);

            //return false if any of the object is false
            if (object.Equals(Object1, default(T)) || object.Equals(object2, default(T)))
                return false;

            //Loop through each properties inside class and get values for the property from both the objects and compare
            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
            {
                if (property.Name != "ExtensionData")
                {
                    string Object1Value = string.Empty;
                    string Object2Value = string.Empty;
                    if (type.GetProperty(property.Name).GetValue(Object1, null) != null)
                        Object1Value = type.GetProperty(property.Name).GetValue(Object1, null).ToString();
                    if (type.GetProperty(property.Name).GetValue(object2, null) != null)
                        Object2Value = type.GetProperty(property.Name).GetValue(object2, null).ToString();
                    if (Object1Value.Trim() != Object2Value.Trim())
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public static Type GetType(Type it)
        {
            Type columnType = Nullable.GetUnderlyingType(it) ?? it;
            return columnType;
        }

        public static string GetName<T>(T myInput) where T : class
        {
            if (myInput == null)
                return string.Empty;

            return typeof(T).Name;
        }

        public static Dictionary<string, Type> GetProperties(Type objType)
        {
            //var lista = (IList)objectproperties;
            //object uniqueobject = null;
            //foreach (var mObject in lista)
            //{
            //    uniqueobject = mObject;
            //    break;
            //}

            //Type objType = objectproperties.GetType();

            //Type myType = uniqueobject.GetType();

            var result = new Dictionary<string, Type>();

            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                //object value = property.GetValue(objectproperties, null);
                string key = property.Name;
                ////var elems = value as ICollection;

                //if (property.PropertyType.Name.Contains("List")
                //     || property.PropertyType.Name.Contains("Enumerable")
                //     || property.PropertyType.Name.Contains("Collection"))
                //{





                //    //var childs = new List<object>();
                //    //foreach (var item in (IEnumerable)value)
                //    //{
                //    //    var child = GetPropertiesValue(item);
                //    //    childs.Add(child);
                //    //}
                //    result.Add(key);

                //}
                //else
                //{

                result.Add(key, property.PropertyType);
            }
        //}


            return result;

        }


        public static T CloneObj<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        public static void CloneObj<T>(T source,ref T destination)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, destination))
            {
                return;
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                destination = (T)formatter.Deserialize(stream);
            }
        }


    }
}
