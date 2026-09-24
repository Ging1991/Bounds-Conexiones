using System;

namespace Bounds.Conexiones {

	public class ConexionNombreDisponible : ConexionBase<ConexionNombreDisponible.Entrada, ConexionNombreDisponible.Salida> {

		private static readonly string METODO = "POST";
		private static readonly string SERVICIO = "/api/nombre-disponible";
		private readonly string nombre;

		public ConexionNombreDisponible(string nombre) : base(METODO, SERVICIO) {
			this.nombre = nombre;
		}

		protected override Entrada GenerarEntrada() {
			return new Entrada {
				nombre = nombre
			};
		}

		[System.Serializable]
		public class Salida {
			public bool estaDisponible;
		}

		[Serializable]
		public class Entrada {
			public string nombre;
		}

	}

}