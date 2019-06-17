# PROGRAMACIÓN 2 - 2019

### EQUIPO 5 : Sofía Nicoletti, Fausto Pieruzzi, Angel Matías Rodriguez, Marcelo Stabile.


# INTRODUCCIÓN

### El Centro Ignis cumple el rol de facilitador de técnicos calificados para proyectos, siendo un intermediario entre el cliente que tiene un proyecto y los técnicos que se registran para trabajar. Para desarrollar estas funciones, necesita una aplicación que permita al centro la administración de recursos humanos para proyectos. Esta aplicación debe ser una mejora significativa al método que actualmente utilizan que se basa en el uso de planillas excel y correos con información.

### Los clientes son estudiantes de la UCU, a futuro podrían ampliarse a egresados. El cliente se contacta con el Centro Ignis presentando su proyecto y realizando solicitudes por los técnicos que necesita.
### Al final del proyecto, el centro debe calcular las horas empleadas por técnico e informarle cuanto debe pagar.

### Los técnicos son estudiantes de la UCU que se registran en el centro para trabajar. Pueden anotarse hasta en 3 roles (hay 22 disponibles). Pueden ser de cualquier año de la carrera, serán catalogados según "niveles de dificultad".
### Podrán estar trabajando hasta un máximo de 3 proyectos concurrentes.

### Los clientes deben registrar su proyecto en el centro, ya que la universidad debe estar al tanto de los proyectos en curso.
### Además de registrar los proyectos, los clientes deben solicitar expresamente los técnicos que necesita.


# LA APLICACIÓN

### La aplicación inicia se muestra una pantalla principal en donde se podra ver en que proyectos se encuentra trbajando el centro ignis, asi como dos botones principales para el registro de clientes o tecnicos y otro boton para ingresar a las cuentas ya creadas.
### Cuando el usuario intente ingresar se presentara el login en donde dependiendo del usuario este ingresara a su correspondiente menú. En este caso son tres opciones:
* acceder al menú de clientes.
* acceder al menú de técnicos.
* acceder al menú de administrador del Centro Ignis.

## MENÚ DE CLIENTES

### El cliente que ingresa a la aplicación por primera vez, deberá registrarse como cliente, ingresando sus datos personales.
### Luego de registrado estará en condiciones de ingresar proyectos a su cuenta de cliente.

### Para dar de alta un proyecto, debe ingresar un nombre de proyecto y una descripción (a modo de presentación).
### Luego de creado el proyecto, el cliente podrá dar de alta una o más solicitudes de técnicos. Deberá ingresar una solicitud por cada técnico que necesita. Un proyecto podrá tener "n" solicitudes de técnicos, por el momento no hay una limitación establecida por el Centro Ignis.

## MENÚ DE TÉCNICOS

### El técnico que ingresa a la aplicación por primera vez, deberá registrarse como técnico, ingresando sus datos personales y seleccionando a los roles a los cuales se postula. Cada rol implica una disciplina (sonidista, músico, etc.). Podrá postularse hasta un máximo de 3 roles, pudiendo cambiar los mismos más adelante, aunque siempre conservando la limitación de 3.

### Una vez registrado, podrá ingresar a la aplicación cuando quiera para visualizar a qué proyecto está asignado y tambien a controlar las horas que viene desarrollando en cada uno.

### Es de interés para el Centro Ignis de brindar al técnico de un historial de sus trabajos, ya que puede servirle como referencia laboral. Por lo tanto, el técnico contará con la opción de descargar un documento que detalle los trabajos que realizó (nombre de los proyectos, el rol que desempeño en cada uno y las horas en cada uno).

### Debido a que el técnico recibe un pago por sus servicios, la aplicación tambien debe permitirle descargar un documento con las horas realizadas por proyecto y el pago que debe recibir por cada uno. Esto tambien le permite al Centro Ignis de alivianar su trabajo administrativo, ya que en todo momento el técnico puede revisar lo que tiene que cobrar sin necesidad de depender del administrador del centro.

## MENÚ DEL ADMINISTRADOR DEL CENTRO IGNIS

### El administrador del Centro Ignis accede a la aplicación y tendrá opciones para visualizar la siguiente información:
* Lista de clientes registrados (pudiendo ver información detallada de cada uno).
* Lista de técnicos registrados (pudiendo ver información detallada de cada uno).
* Lista de proyectos (activos, concluidos).
* Lista de solicitudes por proyecto (activas en cada proyecto activo).
* Lista de costo / hora dependiendo de cada categoría.

### El administrador podrá realizar las siguientes acciones:
* Activar / desactivar clientes (no se borra para preservar sus datos históricos).
* Activar / desactivar técnicos (no se borra para preservar sus datos históricos).
* Asignar uno o mas técnicos a cada proyecto.
* Modificar el costo / hora.
* Modificar el limite de roles por técnico.
* Modificar el limite de proyectos en los que puede estar asignado un técnico.

### Es necesario obtener la siguiente información en reportes:
* Lista de proyectos activos, indicando el cliente en cada caso.
* Lista de horas a pagar por técnico.


## REQUISITOS DE LA APP

* Mantener una base de datos de:
    * clientes.
    * técnicos.
    * proyectos.
    * solicitudes.

* Permitir a los clientes:
    * registrar sus proyectos.
    * registrar solicitudes por los técnicos que necesita.

* Permitir a los técnicos:
    * registrarse como técnico.
    * postularse hasta un máximo de 3 roles.

* Permitir al operador de Ignis:
    * asignar técnicos a los proyectos a partir de las solicitudes.
    * mantener un registro de costo por hora.

* Ignis debe poder contar con la siguiente información:
    * informe de un cliente y sus proyectos y técnicos asignados.
    * informe de proyectos activos y concluidos.
    * informe de técnicos activos e inactivos.
    * informe de técnicos y sus proyectos realizados.

* Fronts:
    * front para clientes
    * front para técnicos
    * front para Ignis (administradores)


## CLASE "PERSONA"

### Considerando EXPERT, decimos que esta clase es experta por mantener el constructor de personas.
### Cumple con SRP ya que esta es su única responsabilidad y solo cambia si hay modificaciones sobre las listas o se agrega otra a futuro.

* Atributos:
    * Nombre completo (Nombre, Apellido)
    * Estado (Activo, Inictivo)
    * e-mail
    * Contraseña

* Comportamientos:
    * cambiarContraseña()
    * MsgError() metodo que muestra mensaje de error.
    * checkForm() matodo que chekea el formulario que llenan los usuarios.

* Colaboraciones:
    * Cliente
    * Tecnico

* Implementa:
    * Clase abstracta "AdminLista"

* Tests asociados a esta clase:
    * Se puede crear un test que controle que el método de actualizar listas no devuelve vacíos o nulos.


## CLASE "CLIENTE" : PERSONA

### Considerando EXPERT, decimos que esta clase es experta en construir un objeto "Cliente" y cambiar sus datos y su estado.
### Cumple con SRP ya que esta es su única responsabilidad y solo cambia si cambia el constructor o se agregan nuevos métodos al objeto.

* Atributos:
    * ListaClientes

* Hereda de PERSONA los siguientes atributos:
    * Nombre completo (nombre y apellido)
    * Estado (activo, inactivo)
    * e-mail
    * Contraseña

* Comportamientos:
    * Constructor del cliente.
    * activar()    método para activar un cliente.
    * inactivar()    método para inactivar un cliente y sus solicitudes y proyectos asociados.

* Colaboraciones:
    * Persona
    * Proyecto

* Tests asociados a esta clase:
    * Si el nombre y el apellido se ingresan en distintos atributos, es importante que al concatenarlos se controle que no existan "espacios" innecesarios entre ellos.
    * Es importante que se controle que la edad ingresada no sea cero o negativa.


## CLASE "TECNICO" : PERSONA

### Considerando EXPERT, decimos que esta clase es experta en construir un objeto "Tecnico" y cambiar sus datos y su estado.
### Cumple con SRP ya que esta es su única responsabilidad y solo cambia si cambia el constructor o se agregan nuevos métodos al objeto.

* Atributos:
    * Presentación (texto)
    * Estudiante o Egresado
    * Año de egreso
    * Edad
    * Nivel de dificultad que puede encarar (básico, avanzado)
    * Calificación de Centro Ignis (asignada por el administrador de Ignis)
    * Calificación asignada por clientes.
    * ListaTecnicos

* Hereda de PERSONA los siguientes atributos:
    * Nombre completo (nombre y apellido)
    * Estado (activo, inactivo)
    * e-mail
    * Contraseña

* Comportamientos:
    * Constructor del técnico.
    * activar()      método para activar un técnico.
    * inactivar()    método para inactivar un técnico.
    * asignarTecnico()  asignar tecnico a uno o mas proyectos.
    * modificarCalificaIgnis()     método para modificar la calificación realizada por Ignis
    * modificarCalificaCliente()   método para modificar la calificación realizada por Clientes

* Colaboraciones:
    * Persona
    * Proyecto

* Tests asociados a esta clase:
    * Si el nombre y el apellido se ingresan en distintos atributos, es importante que al concatenarlos se controle que no existan "espacios" innecesarios entre ellos.
    * Es necesario controlar que exista un método para controlar que el año de egreso no sea menor a cero (o un valor razonable, ejemplo 2015) y que además el valor ingresado tampoco puede ser mayor al año en curso.
    * Es necesario hacer un test sobre los métodos que modifican las calificaciones de clientes y del centro ya que los mismos deben controlar que los valores se encuentran dentro de los rangos establecidos previamente (ejemplo, entre 0 y 5).


## CLASE "ADMINISTRADOR" : PERSONA

### Considerando EXPERT, decimos que esta clase es experta en construir un objeto "Administrador" y cambiar sus datos y su estado.
### Cumple con SRP ya que esta es su única responsabilidad y solo cambia si cambia el constructor o se agregan nuevos métodos al objeto.

* Atributos:
    * ListaAdministradores

* Hereda de PERSONA los siguientes atributos:
    * Nombre completo (nombre y apellido)
    * Edad
    * Estado (activo, inactivo)
    * e-mail
    * Contraseña

* Comportamientos:
    * constructor del administrador.
    * modifCostoPorHora() modificar el precio por hora de los proyectos.
    * modificarLimites() modificar limites de roles o proyectos.
    * agregarTecnico() Agrega tecnico a un proyecto.

* Colaboraciones:
    * Persona
    * Proyecto
    * Roles
    * Config
    * Solicitud

* Tests asociados a esta clase:
    * Si el nombre y el apellido se ingresan en distintos atributos, es importante que al concatenarlos se controle que no existan "espacios" innecesarios entre ellos.


## INTERFASE "IPERSONA"

### Basándonos en el patrón de Polimorfismo, identificamos que ambos objetos comparten los mismos tipos, por lo que creamos esta interfase para activar o desactivar la cuenta de un objeto Cliente o de un objeto Tecnico.

* Comportamientos:
    * activar()
    * inactivar()

* Implementada por:
    * clase "Cliente"
    * clase "Tecnico"


## CLASE "LOGIN"
### Clase con la responsabilidad de redireccionar al usuario a su menu correspondiente y regresarlo al menu principal cuando desee salir del sistema.
### Cumple con SRP ya que esta es su única responsabilidad.

* Comportamientos:
    * ingresar() metodo para que el usuario ingrese al sistema.
    * salir() metodo para que el usuario salga del sistema.
    * MsgError() metodo que muestra mensaje de error.

* Colaboraciones:
    * Persona

* Tests asociados a esta clase:
    * Si el email o contraseña es correcta.
    * Es importante que se controle que no se ingrese nigun campo vacio.
    * Es importante que se controle que el usuario se encuentre activo.


## CLASE "PROYECTO"

### Considerando EXPERT, esta clase es experta en construir un objeto "Proyecto" y mantener sus datos.
### Cumple con SRP ya que esta es su única responsabilidad y solo cambia si se necesita modificar el constructor o agregar nuevos comportamientos.

* Atributos:
    * Nombre
    * Presentación (texto)
    * Estado (activo, concluido)
    * Lista de Solicitudes

* Comportamientos:
    * agregarProyecto() 	método para agregar el proyecto al sistema luego de construido el objeto. Dispara
    * actualizarListaProyectos() de la clase Proyectos y también guarda un registro nuevo en los archivos de texto.
    * agregarSolicitud() 	método para agregar una solicitud de un técnico a las lista de solicitudes.
    * reactivarProyecto()      método para marcar como reactivar un proyecto.
    * concluirProyecto()    método para marcar como concluido un proyecto.
    * checkForm() metodo que revisa el formulario de proyectos
    * MsgEror() metodo que envia mensaje de error. 

* Colaboraciones:
    * Proyectos.
    * Solicitud.

* Tests asociados a esta clase:
    * Testear que el método agregarProyecto() efectivamente agrega un proyecto a la aplicación.
    * Testear que el método agregarSolicitud() efectivamente agrega una solicitud a un proyecto.


## CLASE "PROYECTOS"

### Esta clase tiene como responsabilidad mantener una lista de proyectos y actualizar la lista al inicio de la app, luego de agregar un nuevo proyecto o cambiar el estado de uno existente.

### Considerando EXPERT, decimos que esta clase es experta por mantener una lista de objetos de tipo "Proyecto".
### Cumple con SRP ya que esta es su única responsabilidad y solo cambia si se modifica como se utiliza la misma o se agregan nuevos comportamientos.

* Atributos:
    * Lista de Proyectos

* Comportamientos:
    * actualizarLista() 	método para actualizar la lista al inicio de la app, luego de agregar un nuevo proyecto o cambiar el estado de uno existente.
   

* Colaboraciones:
    * Proyecto

* Implementa:
    * Clase abstracta "AdminLista"


## CLASE "SOLICITUD"

### Considerando EXPERT, esta clase es experta en construir una solicitud de técnico.
### Cumple con SRP ya que esta es su única responsabilidad y solo cambia si cambia el constructor o se agregan comportamientos.

* Atributos:
    * solicitud_Rol
    * solicitud_Nivel
    * solicitud_Observaciones

* Colaboraciones:
    * Proyecto.

## CLASE MAIL
### Considerando EXPERT, esta clase es experta en el envio de un mail.
### Cumple con SRP ya que está es su única responsabilidad y solo cambia si se modifica el constructor o se agregan comportamientos.

* Atributos:
    * Asunto.
    * Remitente.
    * Destinatario.
    * Contenido.

* Comportamientos:
    * Enviar().

* Colaboraciones:
    * MailSenderAPI

## CLASE MailCLIENTE : MAIL
### Considerando EXPERT, esta clase es experta en dar formato al mail de un cliente.
### Cumple con SRP ya que está es su única responsabilidad y solo cambia si se modifica el constructor o se agregan comportamientos.

* Atributos:
    * Cliente.
    * Cuerpo.

* Hereda de la clase MAIL los atributos:
    * Asunto.
    * Contenido.

* Colaboraciones:
    * Mail

## CLASE MailTECNICO : MAIL
### Considerando EXPERT, esta clase es experta en dar formato al mail de un tecnico.
### Cumple con SRP ya que está es su única responsabilidad y solo cambia si se modifica el constructor o se agregan comportamientos.

* Atributos:
    * Cliente.
    * Cuerpo.

* Hereda de la clase MAIL los atributos:
    * Asunto.
    * Contenido.

* Colaboraciones:
    * Mail


## CLASE MailSenderAPI
### Esta clase es experta en el envio de un mail.

* Atributos:
    * adressFrom().
    * nameFrom().
    * passwordFrom().

* Comportamientos:
    * MailSender().
    * GetPassword().
    * SendMail().

* Colaboraciones:
    * Mail.

## CLASE "ROL"

### Considerando EXPERT, esta clase es experta en construir un rol (especialización de los técnicos).
### Cumple con SRP ya que está es su única responsabilidad y solo cambia si se modifica el constructor o se agregan comportamientos.

* Atributos:
    * Identificador, título principal.
    * Descripción, de la actividad que desarrolla.

* Colaboraciones:
    * Roles


## CLASE "ROLES"

### Esta clase tiene como responsabilidad mantener una lista de los roles y actualizar la lista al inicio de la app o luego de agregar un nuevo rol.

### Considerando EXPERT, decimos que esta clase es experta porque su función es solo mantener una lista de objetos de tipo "Roles".
### Cumple con SRP ya que esta es su única responsabilidad y solo cambia si se modifican o agregan comportamientos.

* Atributos:
    * listaRoles[]

* Comportamientos:
    * agregarRol()
    * actualizarLista() 	método para actualizar la lista.

* Colaboraciones:
    * Rol

* Implementa:
    * Clase abstracta "AdminLista"


## CLASE ABSTRACTA "AdminLista"

### Implementamos esta clase abstracta ya que identificamos que las clases Persona, Roles y Proyectos tienen listas que deben ser actualizadas. Como comparten este mismo tipo, podemos aplicar una clase abstracta, una en algunas clases realizamos un override del método ya que el comportamiento debe ser distinto a las demás clases.

* Comportamientos:
    * actualizarLista()

* Implementada por:
    * clase "Personas"
    * clase "Roles"
    * clase "Proyectos"


## CLASE "COSTO"

### Según EXPERT, esta clase es experta porque su función es mantener la información del costo según categoría.
### Cumple con SRP ya que esta es su única responsabilidad y solo cambia si se modifican sus valores o se agregan comportamientos.

* Atributos:
    * Categoria
    * CostoPorHora

* Comportamiento:
    * modificarCostoPorHora()


## CLASE "CONFIG"

### Existen determinados parámetros de la aplicación que podrían variar a futuro pero que no deben ser manipulados por los usuarios.
### Establecemos una clase de "configuración general" para mantener los mismos.

* Atributos:
    * limiteRolesPorTecnico (máx. 3 concurrentes).
    * limiteProyectosPorTecnico (máx. 3 concurrentes).
    * limiteAñosEgresados (ej. 1, 2 o 3 años máximo).

* Comportamientos:
    * modificarRolesPorTecnico()
    * modificarProyectosPorTecnico()
    * modificarAñosEgresados()


## CLASE "dbFormato"

### A los efectos de mantener la información de los objetos en forma local, esta clase recibe los atributos de un objeto, genera una línea a partir de los mismos y la guarda en un archivo de texto. Al inicio de la aplicación esta clase lee los datos y genera los objetos a partir de la información almacenada.

* Comportamientos:
    * CodificarLineaTxt()
    * DecodificarLineaTxt()

* Colaboradores:
    * dbArchivo

* Test asociados a esta clase:
    * Test para asegurar que el método de codificación funciona correctamente a lo esperado.
    * Idém al anterior, sobre el método de decodificación.


## CLASE "dbArchivo"

### A los efectos de mantener la información de los objetos en forma local, esta clase recibe los atributos de un objeto, genera una línea a partir de los mismos y la guarda en un archivo de texto. Al inicio de la aplicación esta clase lee los datos y genera los objetos a partir de la información almacenada.

* Comportamientos:
    * GuardarLinea()
    * EliminarLinea()
    * LeerLineas() = leer todo el archivo.

* Colaboradores:
    * dbFormato

* Test asociados a esta clase:
    * Test para asegurar que el método de leer completamente un archivo no devuelva valores nulos.


## CASOS DE USO DE INTERACCIÓN

## LOGIN
* PASO 1: El usuario ingresa su mail y contraseña. Por lo cual se le envia un mensaje a la clase LOGIN de tipo: login.habilitarINgreso();
* PASO 2: Si este coincide la clase le contesta con un mensaje login.habilitarIngreso();
* PASO 2.1: La clase no encuentra el mail, se envia un mensaje de error al usuario de tipo: login.MsgError();.

## REGISTRO
* PASO 1: El cliente debe llenar un formulario, en donde se le envia mensaje a la clase Persona.checkForm()
* PASO 2: Si los datos fueron llenados correctamente entonces se crea la persona.
* PASO 2.1: Si no encuentra los datos se le envia un mensaje de error al usuario de tipo Persona.MsgError()

## INGRESO PROYECTO
* PASO 1: El Cliente debe llenar un formulario con el nombre del proyecto, descripcion. por lo que envia un mensaje Proyecto.checkForm()
* PASO 2: Si el formulario se llena de manera correcta entonces se envia un correo con la confirmacion de la cracion del proyecto. Mail.Enviar()
* PASO 2.1: Si el formulario no se llena de manera correcta entonces mande mensaje error Proyecto.MsgError().

## ASINGACION TECNICO A PROYECTO
* PASO 1: Una vez presentado el proyecto, y avisando mediante mail a el centro Ignis. El administrador debe ingresar los tecnicos los cuales realizaran el proyecto, enviando un mensaje de tipo Administrador.asignarTecnico()
* PASO 2: Una vez que se asigna se envia un mail al tecnico avisando que el mismo fue asignado a un proyecto. por lo tento se envia un mensaje de MAIL.Enviar()