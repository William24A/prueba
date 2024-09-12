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



4-
    #¿Qué ventajas ve en el uso de fixtures? ¿Qué enfoque(caja negra/blanca) estaría aplicando?
    
    Es de caja negra porque los datos que inicializo en el fixture son solo entradas para las pruebas y no te me importa el comportamiento interno de los objetos o métodos.

    #Ventajas:
    - Reutilización de código: Permite configurar un estado inicial común para todas las pruebas, evitando la repetición de código de configuración.
    - Consistencia: Asegura que todas las pruebas se ejecuten con el mismo conjunto de datos iniciales, lo que puede hacer que las pruebas sean más confiables y consistentes.
    - Facilita el mantenimiento: Si se necesita cambiar los datos de prueba o la configuración inicial, solo se modifica en un lugar, lo que reduce errores y facilita el mantenimiento.
    - Eficiencia: Puede mejorar el rendimiento de las pruebas al configurar el estado una vez para múltiples pruebas, en lugar de hacerlo para cada prueba individual.
    


    #Explique los conceptos de Setup y Teardown en testing:

    - Setup (Configuración):
    . Es el proceso de preparar el entorno para las pruebas.
    . Se ejecuta antes de cada prueba o conjunto de pruebas.
    . Incluye tareas como inicializar objetos, preparar datos de prueba, o configurar conexiones.
    . En nuestro caso, el constructor de TiendaFixture actúa como setup.
    
    - Teardown (Limpieza):
    . Es el proceso de limpiar después de que las pruebas se han ejecutado.
    . Se ejecuta después de cada prueba o conjunto de pruebas.
    . Incluye tareas como liberar recursos, limpiar datos temporales, o cerrar conexiones.
    . En nuestro caso, el método Dispose de TiendaFixture podría actuar como teardown si fuera necesario.


5 - ¿Puede describir una situación de desarrollo para este caso en donde se plantee pruebas de
    integración ascendente? Describa la situación.

    Supongamos que estás desarrollando un sistema de carrito de compras para una tienda en línea:

    Primer paso: Comienzas desarrollando los componentes más pequeños e independientes, como la clase Producto que contiene el nombre, precio y categoría de un producto, y pruebas las funciones que modifican el precio del producto (por ejemplo, aplicar un descuento).

    Segundo paso: Luego desarrollas la clase Tienda, que es responsable de gestionar un inventario de productos, agregar nuevos productos y buscar productos por su nombre. En esta etapa, realizas pruebas de unidad para asegurarte de que estas funciones trabajen correctamente de forma independiente.

    Tercer paso (prueba de integración ascendente): Después de verificar que cada componente individual funciona, integras las funciones. Por ejemplo, integras la clase Tienda con la clase Producto para verificar que las operaciones como agregar productos al carrito, aplicar descuentos y calcular el total del carrito funcionan correctamente juntas.

    Pruebas de integración ascendente: En este caso, las pruebas de integración ascendente se centrarían en verificar que el carrito de compras puede sumar correctamente los precios de los productos, que los descuentos se aplican bien y que todo el sistema funciona de manera integrada.