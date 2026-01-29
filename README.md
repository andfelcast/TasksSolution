# TasksSolution

La solución que se implementó contiene 3 garndes componentes a saber:

## Base de datos

Se adjunta en la carpeta DB el archivo de creación de la base de datos llamada TaskingDB, así como el archivo
de consultas solicitadas y el archivo con manejo de formato json en Sql Server

## Frontend

Se utilizó Angular para su construcción, denotando dos grandes secciones en el menú lateral izquierdo:

### Users

Enfocado en las opciones de creación y listado de usuarios.
Se tienen las opciones de listado, detalle y creación de nuevos usuarios.

## Tasks

Enfocado en las opciones de creación y listado de tareas.
Se tienen las opciones de listado, detalle y creación de nuevas tareas.
Las tareas siempre al principio se crean como Pending, y el cambio de estados se hace hacia adelante, es decir:

    Pending -> InProgress -> Done.

Por el momento no se puede retroceder ni saltar entre estados.

# Pasos de ejecución

Ejecutar el script de base de datos TaskingDB_script.sql
Compilar la solución de Backend y asegurarse que al cargar, muestre las definiciones en swagger en el host https://localhost:7130
Compilar la solución de Frontend utilizando npm install, y luego ng serve -o, respondiendo en el host https://localhost:4200

# Mejoras no tomadas en cuenta en el alcance

Módulo de autenticación y autorización, tanto para frontend como backend y con perfilamiento para acceso a las funciones
Posiblidad de hacer ajustes a las tareas y sus estados retrocediendo estado (opcional si llega a ser aprobado)
Borrado(así sea lógico) de tareas y usuarios
Logs de histórico de tareas y registro de repositorios en los mismos
Extender operaciones de modificaciones de usuarios y tareas

