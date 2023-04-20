# NexuApiTest
code for testing simple Api Web application


1.- Compilación

Descargar la solución como Zip, descomprimir los archivos en la ruta deseada y abrir la solución con Visual Studio 2019. 

Una ves abierto la solución, el IDE iniciara con la descarga de los paquetes Nugets, por lo que es requisito contar con conexión a internet.

Si lo anterior no sucede de forma automática, dar clic derecho sobre la solución, después acceder a la opción Nuget packets fro solution y por ultimo seleccionar Restore..

Una ves terminado el proceso, se recomienda limpiar la solucion y después re compilar.

2.- Ejecución

Hay dos maneras de ejecutar el Api, la primera es asegurándose que el proyecto web este seleccionado como default (ApiTest) y ejecutar desde la barra de herramientas del Visual Studio, la segunda es dar clic derecho sobre este mismo proyecto y seleccionar la opción Debug -> Start New Instance.

Una ves ejecutado el proyecto se abrirá un navegador de internet (el default) mostrando una pagina con el error code 40.3.14 Forbidden, eso nos indica la ejecución correcta del proyecto.

3.- Testing

Pruebas locales: 

Requisitos para probar el api de manera local:

Tener acceso a la base de datos publicada en Azure, la cual está protegida de cualquier conexión directa, se tendría que agregar una regla al firewall con la ip pública del equipo que desea ejecutar la prueba local.

Ejecución de las pruebas locales:

Para probar el api, basta con usar el navegador o bien Postaman o software similar, y llamar cada uno de los métodos con sus parámetros necesarios, por ejemplo:

http://localhost:53246/autos/models/1742/150000

http://localhost:53246/autos/models/Acura/Acura 2023/10

http://localhost:53246/autos/Models/Acura

Sustituyendo el puerto por el indicado en el navegador que se abre cuando se ejecuta la solución, o bien pude ir a las propiedades del proyecto web y setear el puerto de su preferencia.

Pruebas en la nube:

Para las pruebas en la nube se publico en una cuenta de evaluación de Azure en la siguiente dirección:
https://nexuapi.azurewebsites.net/ bastaría con remplazar http://localhost:53246 con https://nexuapi.azurewebsites.net/
