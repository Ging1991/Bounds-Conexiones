using System;
using System.Collections.Generic;

namespace Bounds.Conexiones {

	public class ConexionGuardarResultados : ConexionBase<ConexionGuardarResultados.Entrada, ConexionGuardarResultados.Salida> {

		private static readonly string METODO = "POST";
		private static readonly string SERVICIO = "/api/guardar-resultado";
		private readonly string jugadorGanador;
		private readonly string jugadorPerdedor;
		private readonly List<int> cartasGanadoras;
		private readonly List<int> cartasPerdedoras;

		public ConexionGuardarResultados(
				string jugadorGanador, string jugadorPerdedor, List<int> cartasGanadoras, List<int> cartasPerdedoras) : base(METODO, SERVICIO) {

			this.jugadorGanador = jugadorGanador;
			this.jugadorPerdedor = jugadorPerdedor;
			this.cartasGanadoras = cartasGanadoras;
			this.cartasPerdedoras = cartasPerdedoras;
		}

		protected override Entrada GenerarEntrada() {
			return new Entrada {
				jugadorGanador = jugadorGanador,
				jugadorPerdedor = jugadorPerdedor,
				cartasGanadoras = cartasGanadoras,
				cartasPerdedoras = cartasPerdedoras
			};
		}

		[Serializable]
		public class Salida {
			public bool resultado;
		}

		[Serializable]
		public class Entrada {
			public string jugadorGanador;
			public string jugadorPerdedor;
			public List<int> cartasGanadoras;
			public List<int> cartasPerdedoras;
		}

	}

}