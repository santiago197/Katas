using AwesomeAssertions;

namespace Elevador;

public class ElevadorTests
{
    [Fact]
    public void Si_LlamoElevadorDesdePiso1YEstaEnPiso1_Debe_AbrirPuertas()
    {
        var elevador = new Elevador();
        elevador.Llamar(1, Direccion.Arriba);

        elevador.PisoActual.Should().Be(1);
        elevador.PuertaEstaAbierta.Should().BeTrue();
    }

    [Fact]
    public void Si_ElevadorEstaEnElPiso1YMuevoAlPiso2_Debe_PisoActualSer2()
    {
        var elevador = new Elevador();
        var pisoDestino = 2;

        elevador.Mover(pisoDestino);

        elevador.PisoActual.Should().Be(2);
    }

    [Fact]
    public void Si_ElevadorSeMueveAPiso3_Debe_PisoActual3YRecorridoSer123()
    {
        var elevador = new Elevador();
        var pisoDestino = 3;

        elevador.Mover(pisoDestino);

        elevador.PisoActual.Should().Be(pisoDestino);
        elevador.Recorrido.Should().BeEquivalentTo(new List<int>() { 1, 2, 3 });
    }

    [Fact]
    public void Si_ElevadorSeMueveAlPiso5_Debe_RecorridoSer12345()
    {
        var elevador = new Elevador();
        var pisoDestino = 5;

        elevador.Mover(pisoDestino);

        elevador.Recorrido.Should().BeEquivalentTo(new List<int>() { 1, 2, 3, 4, 5 });
    }

    [Fact]
    public void Si_LlamoElevadorDesdePiso2YElevadorEnPiso1_Debe_IrAlPiso2YAbrirPuertas()
    {
        var elevador = new Elevador();

        const int pisoSolicitado = 2;
        elevador.Llamar(pisoSolicitado, Direccion.Arriba);

        elevador.PisoActual.Should().Be(pisoSolicitado);
        elevador.PuertaEstaAbierta.Should().BeTrue();
    }

    [Fact]
    public void Si_ElevadorEstaEnPiso5YSeLLamaAlPiso1_Debe_MostrarElUltimoRecorrido()
    {
        var elevador = new Elevador();

        elevador.Mover(5);
        elevador.Mover(1);

        elevador.Recorrido.Should()
            .BeEquivalentTo(new List<int>() { 5, 4, 3, 2, 1 }, options => options.WithStrictOrdering());
        elevador.PisoActual.Should().Be(1);
    }

    [Fact]
    public void Si_ElevadorTienePuertaAbiertaEIntentoMover_Debe_LanzarExcepcion()
    {
        var elevador = new Elevador();
        const int pisoSolicitado = 2;
        elevador.Llamar(pisoSolicitado, Direccion.Arriba);

        var caller = () => elevador.Mover(6);

        caller.Should().ThrowExactly<InvalidOperationException>();
    }

    [Fact]
    public void Si_ElevadorEsLlamadoAlPiso2YEsSolicitadoAlPiso3_Debe_IrAlPiso3YAbrirPuertas()
    {
        var elevador = new Elevador();
        const int pisoSolicitado = 2;
        elevador.Llamar(pisoSolicitado, Direccion.Arriba);
        const int pisoDestino = 3;

        elevador.Solicitar(pisoDestino);

        elevador.PisoActual.Should().Be(pisoDestino);
        elevador.PuertaEstaAbierta.Should().BeTrue();
    }

    [Fact]
    public void Si_ElevadorEsLlamadoAlPiso5ConDireccionArribaYEsSolicitadoAlPiso3_Debe_LanzarExcepcion()
    {
        var elevador = new Elevador();
        elevador.Llamar(5, Direccion.Arriba);

        Action caller = () => elevador.Solicitar(3);

        caller.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("El piso destino no corresponde a la dirección");
    }

    [Fact]
    public void Si_ElevadorEsLlamadoAlPiso5ConDireccionAbajoYEsSolicitadoAlPiso6_Debe_LanzarExcepcion()
    {
        var elevador = new Elevador();

        elevador.Llamar(5, Direccion.Abajo);
        var caller = () => elevador.Solicitar(6);

        caller.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("El piso destino no corresponde a la dirección");
    }

    [Fact]
    public void Si_SolicitamosUnElevadorAlPiso1_Debe_RegistrarEvento()
    {
        var elevador = new Elevador();

        elevador.Solicitar(1);

        elevador.Eventos[0].Nombre.Should().Be("Puerta cerrada.");
    }

    [Fact]
    public void Si_SolicitamosUnElevadorAlPiso2_Debe_RegistrarEventosCerrarPuertaPiso1Piso2AbrirPuerta()
    {
        var elevador = new Elevador();

        elevador.Solicitar(2);

        elevador.Eventos[0].Nombre.Should().Be("Puerta cerrada.");
        elevador.Eventos[1].Nombre.Should().Be("Piso 1.");
        elevador.Eventos[2].Nombre.Should().Be("Piso 2.");
        elevador.Eventos[3].Nombre.Should().Be("Puerta abierta.");
    }

    [Fact]
    public void Si_SolicitoElevadorEnPiso1ElEventoInicial_Debe_SerNombrePuertaCerradaMomento1()
    {
        var elevador = new Elevador();

        elevador.Solicitar(1);
        var eventoEsperado = elevador.Eventos[0];

        eventoEsperado.Momento.Should().Be(1);
        elevador.Eventos.Should().HaveCount(2);
        eventoEsperado.Nombre.Should().Be("Puerta cerrada.");
    }

    [Fact]
    public void Si_LlamoElevador_Debe_RegistrarLosEventosEnMomentosCorrespondientes()
    {
        var elevador = new Elevador();

        elevador.Llamar(2, Direccion.Arriba);

        elevador.Eventos[0].Nombre.Should().Be("Puerta cerrada.");
        elevador.Eventos[0].Momento.Should().Be(1);
        elevador.Eventos[1].Nombre.Should().Be("Piso 1.");
        elevador.Eventos[1].Momento.Should().Be(2);
        elevador.Eventos[2].Nombre.Should().Be("Piso 2.");
        elevador.Eventos[2].Momento.Should().Be(3);
        elevador.Eventos[3].Nombre.Should().Be("Puerta abierta.");
        elevador.Eventos[3].Momento.Should().Be(4);
    }

    public enum Direccion
    {
        Arriba,
        Abajo
    }

    public class Elevador()
    {
        public bool PuertaEstaAbierta { get; private set; }
        public int PisoActual { get; private set; } = 1;
        public List<int> Recorrido { get; private set; } = [];
        public List<Evento> Eventos { get; private set; } = [];

        private Direccion _direccion;

        private int _momentoActual = 0;


        public void Llamar(int pisoSolicitado, Direccion direccion)
        {
            CerrarPuerta();
            Mover(pisoSolicitado);
            AbrirPuerta();
            _direccion = direccion;
        }


        public void Solicitar(int pisoDestino)
        {
            ValidarDireccion(pisoDestino);
            CerrarPuerta();
            Mover(pisoDestino);
            AbrirPuerta();
        }

        public void Mover(int pisoDestino)
        {
            if (pisoDestino == PisoActual)
                return;

            ValidarPuertaAbierta();
            AsignarRecorrido(pisoDestino);
        }

        private void ValidarDireccion(int pisoDestino)
        {
            if ((_direccion.Equals(Direccion.Arriba) && Bajando(pisoDestino)) || (
                    _direccion.Equals(Direccion.Abajo) && Subiendo(pisoDestino)))
                throw new InvalidOperationException("El piso destino no corresponde a la dirección");
        }

        private bool Subiendo(int pisoDestino) => pisoDestino > PisoActual;
        private bool Bajando(int pisoDestino) => pisoDestino < PisoActual;

        private void AbrirPuerta()
        {
            PuertaEstaAbierta = true;
            AgregarEvento("Puerta abierta.");
        }

        private void AgregarEvento(string nombre)
        {
            _momentoActual++;
            Eventos.Add(new Evento(_momentoActual, nombre));
        }

        private void CerrarPuerta()
        {
            PuertaEstaAbierta = false;
            AgregarEvento("Puerta cerrada.");
        }

        private void ValidarPuertaAbierta()
        {
            if (PuertaEstaAbierta)
                throw new InvalidOperationException();
        }

        private void AsignarRecorrido(int pisoDestino)
        {
            Recorrido.Clear();

            while (PisoActual != pisoDestino)
            {
                AgregarEvento($"Piso {PisoActual}.");
                Recorrido.Add(PisoActual);
                if (PisoActual >= pisoDestino)
                    PisoActual--;
                else
                    PisoActual++;
            }

            AgregarEvento($"Piso {pisoDestino}.");
            Recorrido.Add(pisoDestino);
        }
    }
}

public class Evento(int momento, string nombre)
{
    public int Momento { get; set; } = momento;
    public string Nombre { get; } = nombre;
}