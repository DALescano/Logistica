Ejemplo:
1.	Web/App Config

	<appSettings>
	   <add key="SSRS_SERVER" value="http://localhost/ReportServer"/>	   
	   <add key="SSRS_USER" value="usuario"/>
	   <add key="SSRS_PASSWORD" value="contrasenia"/>
	   <add key="SSRS_DOMAIN" value="localhost"/>
	   <add key="SSRS_PATH_REPORTS" value="/Reports"/>
	</appSettings>

2.	.Net
	
	//Referencia
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Configuration;	
	using Med.Comun.ReportingServices;
	
	//Uso
	    //NameValueCollection keys = ConfigurationManager.AppSettings;
	    var rm = new ReportManager {UseCredential = true};
	    
	    //Crear Reporte
        string ReportRdl = "/ReportesSGP/ReportePersonal"; //keys["SSRS_PATH_REPORTS"]
        string contentRdl = System.IO.File.ReadAllText(@"C:\Temp\rpt_xxx_Dinamico.rdl");
        
        var srr = rm.CreateReportToServer(ReportRdl, contentRdl);	    
	
	    //Obtener Reporte
	    string nombre = "luis";
        var fileResponse = rm.GetReportFromServer(ReportRdl, ReportFormat.PDF,
                new Dictionary<string, string>
                {
                    {"nombres", nombre}
                });
	