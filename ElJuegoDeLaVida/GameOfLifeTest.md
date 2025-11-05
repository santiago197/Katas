- Cualquier célula viva con menos de dos vecinas vivas muere, 
      como si la causa fuera la infrapoblación.
- Cualquier célula viva con dos o tres vecinas vivas pasa a la siguiente generación.
- Cualquier célula viva con más de tres vecinas vivas muere, como por sobrepoblación.
- Cualquier célula muerta con exactamente tres vecinas vivas se convierte en una célula viva, 
      como por reproducción.



# Creacion tablero (Estado inicial)

- [x] Al instanciar un tablero, que el tablero no sea null.
- [x] Al crear tablero con ciertas dimensiones, y enviar una coordenadas que no pueda tener el tablero
     retornar error.
- [] Tablero según dimensiones sin asignar celular vivas, deberian todas estar muertas.

# Cuando: En un tablero de 3x3 y la coordenada para evaluar vecinos es 1, 1
    El vecino de arriba debe ser 1 2
    El vecino de abajo dede ser 1 0
    El vecino de la izquierda es 0 1
    El vecino de la derecha es 2 1
    El vecino de arriba izquierda 0 2
    El vecino de arriba derecha 2 2
    El vecino de abajo izquierda 0 0
    El vecino de abajo derecha 2 0




# Pruebas de célula
- [] Asignar células vivas en el tablero según coordenadas dadas
- [] Asignar células vivas en el tablero como estado inicial, y obtener total de celulas vivas.
- [] Asignar células vivas en el tablero como estado inicial, y obtener total celulas muertas.
- [] Asignar estado de célula a una coordenada 

# Obtener vecinos según la coordenada

