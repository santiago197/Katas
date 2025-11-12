Kata “Máquina expendedora”
En este ejercicio deberás construir el “cerebro” de una máquina expendedora.
# Funcionalidad
- Aceptará dinero
- Dará cambio, 
- Tiene inventario  
- Despachará productos.
- 
- Todas las funciones que podrías esperar de una máquina expendedora. A continuación se detallan las características.

# Monedas aceptadas
La máquina aceptará monedas válidas (níqueles, dimes y cuartos de dólar) y rechazará monedas inválidas (centavos). Valores de las monedas:
- Penny (centavo) – 1 ¢ //NO ES VALIDA
- Nickel – 5 ¢
- Dime – 10 ¢
- Quarter – 25 ¢
# CRITERIOS DE ACEPTACIÓN 
- Cuando se inserta una moneda válida, el valor de ésta se añade al monto actual y la pantalla se actualiza. 
- Cuando no se ha insertado ninguna moneda, la máquina muestra INSERT COIN.
- Las monedas rechazadas se colocan en la devolución de monedas (“coin return”).
- 
# Selección de producto
Hay tres productos: 
- cocacola por 1,00 US$
- chips por 0,50 US$ 
- caramelos por 0,65 US$. 

- Cuando se pulsa el botón correspondiente y se ha insertado suficiente dinero, se despacha el producto y la máquina muestra THANK YOU durante 5 segundos.
- Después de eso, mostrará INSERT COIN y el monto actual será restablecido a 0,00 US$.
- Si no se ha insertado suficiente dinero, la máquina mostrará PRICE seguido del precio del artículo durante 5 segundos.
- Luego la pantalla mostrará o bien INSERT COIN o el monto actual ingresado, según sea el caso.

# Dar cambio
Cuando se selecciona un producto que cuesta menos que la cantidad de dinero insertada en la máquina, el monto restante se coloca en la devolución de monedas.

# Devolver monedas
Cuando se pulsa el botón de “return coins” (devolver monedas), el dinero que el cliente ha colocado en la máquina le es devuelto y la pantalla muestra INSERT COIN.

# Agotado
Cuando el artículo seleccionado por el cliente está fuera de stock, la máquina muestra SOLD OUT durante 5 segundos.
Después de eso, mostrará el monto de dinero que queda en la máquina o bien INSERT COIN si no hay dinero en la máquina.

# Sólo cambio exacto
Cuando la máquina no es capaz de dar cambio para alguno de los artículos que vende, mostrará EXACT CHANGE ONLY en lugar de INSERT COIN.