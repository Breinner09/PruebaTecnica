## Instalación

En este repositorio se encuenta un archivo **"queryDatabase.txt"**. De allí se debe extraer la información y ejecutarlo en <br>
*Microsoft SQL Server Management Studio*. Con este query se creará la base de datos y sus tablas correspondientes para el correcto funcionamiento del aplicativo.<br>

Con la base de datos creada, se podra abrir la solución en *Visual Studio*, esta se encuentra en la carpeta de **Back** <br>
Cuando se abra la solución, debe ingresar al archivo **"appsettings.json"** y modificar la cadena: <br>

"ConexionSQL": "Server=servidorLocal; Database=pruebaTecnica; Trusted_Connection=True; TrustServerCertificate=True;"<br>

Reemplazando **"servidorLocal"** por el nombre de su servidor. <br>
*Ejecutar el proyecto una vez se haya realizado este cambio*.<br><br>
Una vez inicializado el back, debe abrir la carpeta con el nombre **Front** en Visual Studio Code, abrir una terminal <br>
*(Ctrl + Mayus + ñ)* y ejecutar el comando **"npm install"**. <br>


*Una vez finalizado el proceso de instalación de paquetes podrá ejecutar el proyecto con el comando **"ng serve"***.<br><br>

**Con estos pasos se podrá visualizar mi propuesta para dar solución a la prueba técnica**.<br>
## De antemano, muchas gracias.

