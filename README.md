# Prueba técnica Meico SA
Hola, en este repositorio está alojado el proyecto que resuelve el CASO 3. del documento de Assesment para desarrollador JR. La aplicación está construida en ASP .NET MVC con versión 7.0 de C#. Para que sea posible correr el proyecto considere tener instalados los siguientes programas:

- Visual Studio 2022
- SQL Server
- SQL SERVER Management Studio 19
- Git


# Instalación del proyecto

## Base de datos

Una vez clonado este repositorio, en su máquina local debe estar corriendo un servidor SQL SERVER para poder alojar la base de datos.

En la raíz del repositorio se encuentra un archivo .bak, debe importarlo en su servidor y como resultado tendrá la base de datos **MeicoAssesment** en la cual se encuentran todas las tablas y procedimientos almacenados para el funcionamiento del aplicativo.

[Instrucciones para restaurar archivo .bak en SQL SERVER Management Studio](https://www.ibm.com/docs/es/license-metric-tool?topic=database-restoring-ms-sql-server)

Para asegurar que la app web tenga acceso a la base de datos, se debe crear un login en el servidor local SQL SERVER, considere ejecutar el siguiente script:

```  
USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [MeicoMaster]    Script Date: 4/15/2024 10:38:15 PM ******/
CREATE LOGIN [MeicoMaster] WITH PASSWORD=N'F4gHbASrfEzAnJ6dQ4gK1+R7GOnCRVs9WXtr08yuZh8=', DEFAULT_DATABASE=[MeicoAssesment], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO

ALTER LOGIN [MeicoMaster] DISABLE
GO

ALTER SERVER ROLE [sysadmin] ADD MEMBER [MeicoMaster]
GO

ALTER SERVER ROLE [securityadmin] ADD MEMBER [MeicoMaster]
GO

ALTER SERVER ROLE [serveradmin] ADD MEMBER [MeicoMaster]
GO

ALTER SERVER ROLE [setupadmin] ADD MEMBER [MeicoMaster]
GO

ALTER SERVER ROLE [processadmin] ADD MEMBER [MeicoMaster]
GO

ALTER SERVER ROLE [diskadmin] ADD MEMBER [MeicoMaster]
GO

ALTER SERVER ROLE [dbcreator] ADD MEMBER [MeicoMaster]
GO

ALTER SERVER ROLE [bulkadmin] ADD MEMBER [MeicoMaster]
GO
  
```

*Si no desea ejecutar el script, por favor cambie las propiedades de la cadena de conexión a base de datos que está en el archivo appsettings.json de la aplicación web a las propiedades de un login valido en su servidor local SQL SERVER.*

## Funcionamiento del aplicativo web

Una vez terminadas todas las configuraciones de base de datos, puede correr el aplicativo web abriendo la solución en Visual Studio 2022.

En la base de datos ya estarán varios usuarios registrados, pero si desea una experiencia desde cero, puede registrarse utilizando el enlace de la parte inferior del Login. A continuación se proporcionan dos usuarios registrados en el backup de la base de datos.

assesmentmeico@gmail.com     MeicoAssesment2024#
juancamdev@gmail.com         Luz31101311#


## Agradecimientos
Agradezco sinceramente poder ser parte de este proceso de selección y la comprensión del equipo de atracción de talento humano para la situación en la que me encuentro actualmente. 
Espero poder cumplir con las expectativas de esta prueba técnica y recibir un buen feedback de su parte.
