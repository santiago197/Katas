 - [ ] 

#Diccionario

Llamar: Pedir que el elevador llegue a algún piso específico.
Ir: Ejecutar la orden de ir a un piso específico.

# Lift

- Un ascensor tiene un panel de botones que los pasajeros pueden pulsar para solicitar las plantas.
- Se puede llamar al ascensor desde otras plantas. La llamada debe incluir tanto la planta como la dirección deseada.
- Un ascensor tiene puertas que pueden estar abiertas o cerradas.
- Un ascensor cumple la solicitud cuando se dirige a la planta solicitada y abre las puertas.
- Un ascensor se desplaza entre varias plantas.
- Un ascensor cumple la solicitud cuando se dirige a la planta correcta, está a punto de ir en la dirección indicada y abre las puertas.
- Un ascensor solo puede desplazarse entre plantas si las puertas están cerradas.
- No hay teletransportación, si existe unidad de tiempo "momento"

# Reglas

- El ascensor se mueve tiempo por tiempo.
- El edificio tiene 10 pisos comenzando desde el 1.
- Los ascensores solo pueden tener un llamado.
- Los ascensores solo pueden tener un request.
- **Dirección (sentido) de movimiento**: se refiere a subir (↑) o bajar (↓).

# Test List
- [x] Si llamo el ascensor desde el piso 1 con dirección hacia arriba y está en el piso 1 debe abrir las puertas.
- [x] Si el ascensor esta en el piso 1 y lo muevo al piso 2 el piso actual debe ser 2
- [x] Si el ascensor está en el piso 1 y lo muevo al piso 3 el piso actual debe ser 3 el recorrido debe ser 1,2,3
- [ ] Si el ascensor está en el piso 1 y lo muevo al piso 5 el recorrido debe ser 1,2,3,4,5
- [x] Si llamo el ascensor desde el piso 2 con dirección hacia arriba y está en el piso 1 debe ir al piso 2 y abrir puertas
- [] Si llamo el ascensor desde el piso 3 con dirección hacia arriba y está en el piso 1 debe ir al piso 3 debe mostrar el recorrido
- 

# Casos de borde
- [] Validar límite inferior y superior
- [] 