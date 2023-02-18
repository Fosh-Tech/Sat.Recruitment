# SAT Recruitment

El objetivo de esta prueba es refactorizar el código de este proyecto.
Se puede realizar cualquier cambio que considere necesario en el código y en los test.


## Requisitos 

- Todos los test deben pasar.
- El código debe seguir los principios de la programación orientada a objetos (SOLID, DRY, etc...).
- El código resultante debe ser mantenible y extensible.


## Realización

### 1) Actualizar la versión de .NET

Actualizar la versión 3.1 de .NET Core a la versión actual 7 de .NET.  
La versión 11 de C# invita a reescribir el código de manera más legible.  
Los cambios más notables se hacen visibles en `Program.cs`.

### 2) Evitar _hard code_

La ruta del fichero de datos la llevo al fichero `appsettings.json`.

### 3) Introducir conceptos de Domain-Driven Design

En primer lugar, divido la estructura de la solución en proyectos Api, Domain e Infrastructure.
Esta estructura también se corresponde con una estructura clásica N-capas.

Además, destacar los siguientes aspectos:
- El acceso a datos debe estar en la capa de infraestructura.  
  En este caso, se utiliza el sistema de ficheros (`Users.txt`).  
  Nótese en el método `GetUsers` de `DataContext` el uso de bloqueos para evitar errores
  debidos a accesos concurrentes.
- La clase `User` debe estar en el dominio y debe responsabilizarse únicamente de cuestiones relativas
  a la propia lógica del dominio, como son las validaciones o las reglas como `ApplyNewUserGif`.
- Al tratarse de un proyecto pequeño dejo en el mismo algunas cuestiones "cross", como el uso de patrones
  Specification, Notification.
- Como mejora, sugiero introducir patrones Unit of Work y Repository cuando evolucione la aplicación.

### 4) Inyección de dependencias

El fichero de usuarios se crea desde la capa de la aplicación para pasárselo a `DataContext` como
objeto `Stream`. De este modo, puedo utilizar un objeto `FileStream` desde la API pero también un
objeto `MemoryStream` en las pruebas unitarias.

Es importante observar el cambio de dependencias a _fixtures_ en el proyecto `Test` de pruebas
unitarias. De este modo, el uso de un `MemoryStream` evita la dependencia del sistema de ficheros
en las pruebas unitarias.

(_[Best practices](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices#best-practices):
Try not to introduce dependencies on infrastructure when writing unit tests.)_

### 5) Revisión de la API

Se recomienda rediseñar la API para que sea REST.

- "POST /create-user"  
Aunque en este punto del desarrollo no se utilice esta interfaz, no puedo cambiarla sin incumplir
el requisito de refactorizar. Por este motivo mantendré el paso de parámetros por querystring, aunque la
práctica habitual en un método POST de una API REST es incluir los datos en el cuerpo del
mensaje en formato json.  
La clase `Result` es evidente que no es una buena práctica cuando `IsSuccess=false` y el código
HTTP devuelto es OK 200.   
Lo que sí puedo hacer sin violar el requisito de refactorizar es corregir los códigos
de estado HTTP devueltos para que tengan significado (200 OK, 400 Bad Request).
