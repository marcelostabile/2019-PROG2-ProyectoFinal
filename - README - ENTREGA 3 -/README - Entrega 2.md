#
# PROGRAMACIÓN 2 - 2019
#
## README PARA ENTREGA 2

## __CLASE PERSONA__
###
### Responsabilidades:
* Implementa los tipos para __activar / desactivar el status__ (estado de operación) de una persona, también para __cambiar su contraseña__.
* Conoce los atributos básicos para la construcción de una persona: nombre, correo, contraseña.
###
### Polimorfismo:
#### Las clases __Administrador, Cliente y Tecnico__ utilizan los todos los tipos y atributos de esta clase.
#### Por este motivo aplicamos __Herencia__, quedando la clase Persona como superclase de estas.
###
### Colaboraciones:
* Administrador 
* Cliente
* Tecnico
* Check
* ValidarContrasena
* ValidarEmail
###
### Métodos:
* activar()
* inactivar()
* cambiarContrasena()
###
###
## __CLASE ADMINISTRADOR__
###
### Responsabilidades:
* El Administrador es el único usuario que puede realizar estas acciones.
* Usa los tipos de Proyecto para __cerrar / reabrir un proyecto__.
* Usa los tipos de Solicitud para __asignar / desasignar un técnico a una solicitud__.
### 
### Polimorfismo:
#### __Hereda de la clase Persona__ sus tipos y atributos.
### 
### Colaboraciones:
* Persona
* Proyecto
* Solicitud
###
### Métodos:
* asignarTecnico()
* desasignarTecnico()
* cerrarProyecto()
* reabrirProyecto()
### 
### 
## CLASE CLIENTE
###
### Responsabilidades:
* El Cliente es el único usuario que puede realizar estas acciones:
* __Crear un proyecto__.
###
### Colaboraciones:
* Persona
* Proyecto
###
###
## CLASE TECNICO
###
### Responsabilidades:
* Tiene la responsabilidad de implementar los tipos para __modificar su Calificación Ignis__ y __modificar su Calificación de Clientes__.
* Conoce los atributos para la __presentación personal__, para definir el __nivel de experiencia__ del técnico y sus __calificaciones__.
###
### Colaboraciones: 
* Persona
* ListaRol
### 
### Métodos:
* modificarCalificacionIgnis()
* modificarCalificacionClientes()
### 
### 
