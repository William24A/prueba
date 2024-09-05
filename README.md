# Resolución tp n°1
# Miembros: Albarracin, William - Diaz, Alvaro


---
- [Instalacion](#instalación)


## Instalación

### Configuración y ejecución de la aplicación
Para configurar, instalar y ejecutar el programa siga estos pasos. Asegurate de tener .NET instalado

### Cloná el repositorio
Primero, cloná este repositorio en tu máquina local usando el siguiente comando en tu terminal:

git clone https://github.com/William24A/prueba.git

### Abrí el Proyecto en tu Entorno de Desarrollo (IDE)
Abrí tu entorno de desarrollo preferido y seleccioná "Open Project" (Abrir Proyecto) o su equivalente. Navegá hasta la carpeta del proyecto que acabas de clonar y ábrilo. Debberas estar posicionado sobre la carpeta test.

### Ejecutá la Aplicación
Una vez realizado esto abre la terminal y ejecuta los test con el comadno:

dotnet test


--- 

1 - ¿Puedes identificar pruebas de unidad y de integración en la práctica que realizaste?
Identifique de las dos:
    Pruebas de Unidad
        El constructor de producto, porque solo esta probando que la clase se inicializa
        correctamente sin depender de otras clases.

    Pruebas de integración
        Las pruebas para para verificar el funcionamiento de la clase Tienda, como agregar, buscar o 
        elimnar dependen de producto. En ese casos serian pruebas de integración.


2 - Podría haber escrito las pruebas primero antes de modificar el código de la aplicación?
    
    Sí, sto es lo que se conoce como Desarrollo Guiado por Pruebas o TDD (Test-Driven Development). 
    TDD es un enfoque de desarrollo en el que las pruebas se escriben antes de implementar la lógica del código.
    
    ¿Cómo sería el proceso de escribir primero los tests?
    El ciclo de TDD sigue tres pasos:
    1 - Escribes una prueba que verifique el comportamiento que deseas. Como el código aún no está          implementado, la prueba debería fallar.

    2 - A continuación, implementas el código para que la prueba pase.

    3 - Una vez que las pruebas pasan, puedes mejorar el código si es necesario, asegurándote de que todas las pruebas sigan pasando. 