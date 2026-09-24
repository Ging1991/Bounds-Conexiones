using System;

namespace Bounds.Conexiones {

	public class ConexionCrearJugador : ConexionBase<ConexionCrearJugador.Entrada, ConexionCrearJugador.Salida> {

		private static readonly string METODO = "POST";
		private static readonly string SERVICIO = "/api/crear-jugador";
		private readonly string nombre;

		public ConexionCrearJugador(string nombre) : base(METODO, SERVICIO) {
			this.nombre = nombre;
		}

		protected override Entrada GenerarEntrada() {
			return new Entrada {
				nombre = nombre
			};
		}

		[System.Serializable]
		public class Salida {
			public bool jugadorCreado;
		}

		[Serializable]
		public class Entrada {
			public string nombre;
		}

	}

}