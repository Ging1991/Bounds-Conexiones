using System;

namespace Bounds.Conexiones.Servicios {

	public class ServicioCrearJugador : ServicioBounds<ServicioCrearJugador.Entrada, ServicioCrearJugador.Salida> {

		private static readonly string METODO = "POST";
		private static readonly string SERVICIO = "/api/crear-jugador";

		public ServicioCrearJugador(string nombre) : base(METODO, SERVICIO) {
			entrada = new Entrada {
				nombre = nombre
			};
		}

		[Serializable]
		public class Salida {
			public bool jugadorCreado;
		}

		[Serializable]
		public class Entrada {
			public string nombre;
		}

	}

}