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



3 -

    - En lo que va del trabajo práctico, ¿puedes identificar 'Controladores' y 'Resguardos'?
        La clase Tienda actua como un controlador porque se encarga de llamar a los metodos que
        activan los test.
        
        El mock de la clase Producto es un resguardo porque simulan su comportamiento sin 
        tener que crear uno.
    
    - ¿Qué es un mock? ¿Hay otros nombres para los objetos/funciones simulados?
    Un mock es un objeto simulado que imita el comportamiento de objetos reales de una manera controlada. Se utiliza en pruebas unitarias para aislar el código que se está probando de sus dependencias.
    
    . Stub: Es un objeto simulado que devuelve valores predefinidos y no realiza ninguna lógica adicional. Normalmente se utiliza cuando no se necesita verificar las interacciones, sino solo proporcionar una implementación mínima.
    
    . Spy: Similar a un mock, pero a diferencia del mock, que se centra en verificar interacciones, un spy también puede registrar información sobre cómo se utilizó, permitiendo inspecciones posteriores.
    
    . Fake: Un fake es una implementación completa pero simplificada de una dependencia, que se usa principalmente en pruebas de integración cuando se requiere una versión funcional de un objeto, pero que no interactúe con sistemas externos reales.
    
    . Dummy: Es un objeto simulado que no se utiliza realmente, pero se pasa en un método porque es necesario tener un argumento de ese tipo.
4 -
    - ¿Qué ventajas ve en el uso de fixtures? ¿Qué enfoque estaría aplicando?

        La mayor ventaja de usar fixture es la reutilización de código, esto porque no debo inicializar todo el tiempo mi contenido de la fixture sino inicializo al principio y se utiliza en todas las pruebas. Esto se nota mas cuando se utiliza para inicializar objetos complejos. Otro veneficio seria el ordenamiento del código, al no tener que inicializar todo el tiempo los objetos, se realiza un código mas simple y mas claro.

        El enfoque que estaría aplicando seria uno modular y eficiente en pruebas automáticas, esto se debe a que en lugar de tener pruebas independiente que inicialicen los objetos y luego los destruyan para iniciar otros, tenemos un conjunto de objetos para utilizar durante todos los test.
    
    - Explique los conceptos de Setup y Teardown en testing.
    
        Conceptos de Setup y Teardown en Testing
        1- Setup: seria la preparación previa a utilizar los test, su objetico es configurar el entorno para las pruebas, en este caso seria la creación de los objetos antes de utilizarlos.
        2- Teardown: seria la limpieza del entorno después de realizar las pruebas, en este caso a través de la interfaz IDisposable con el método Dispose, eliminan el contenido de la fila de productos. 