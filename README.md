# Idea General
Se desea realizar el desarrollo de un sitio web, para un juego de preguntas y respuestas.
Los usuarios administradores (gestionan los juegos y sus datos) deberán tener usuario de logueo
(único en el Sistema), contraseña, y nombre completo. Los jugadores no tendrán usuario propio, ya
que jugar será de acceso público.
# Arquitectura Solicitada
 Se podrán acceder a la información y se podrán realizar tareas / juegos a través de un sitio web,
que será publicado en un servidor contratado para dicha funcionalidad.
 La lógica de negocio del sistema estará ubicada dentro de otro servidor, y se podrá acceder a ella
mediante un contrato de servicio publicado en el mismo servidor.
 La base de datos estará instalada en un servidor de datos. La persistencia se comunicara con
dicho servidor mediante ADO.NET.
