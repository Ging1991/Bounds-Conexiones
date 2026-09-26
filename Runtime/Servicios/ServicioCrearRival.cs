using System;

namespace Bounds.Conexiones.Servicios {

	public class ServicioCrearRival : ServicioBounds<ServicioCrearRival.Entrada, ServicioCrearRival.Salida> {

		private static readonly string METODO = "POST";
		private static readonly string SERVICIO = "/api/crear-rival";

		public ServicioCrearRival(string jugadorNombre, string mazoNombre, string cartas) : base(METODO, SERVICIO) {

			entrada = new Entrada {
				jugadorNombre = jugadorNombre,
				mazoNombre = mazoNombre,
				cartas = cartas
			};
		}

		[Serializable]
		public class Salida {
			public bool resultado;
			public string mensaje;
		}

		[Serializable]
		public class Entrada {
			public string jugadorNombre;
			public string mazoNombre;
			public string cartas;
		}

	}

}