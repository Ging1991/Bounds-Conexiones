using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Bounds.Conexiones {

	public abstract class ServicioBounds<Entrada, Salida> : ServicioWeb {

		private const string URL_BASE = "https://tcg-backend-prod.carloscaballeromorel.workers.dev";
		private const int TIMEOUT_SEGUNDOS = 15;
		protected Entrada entrada;

		public ServicioBounds(string metodo, string servicio) : base(metodo, $"{URL_BASE}{servicio}", TIMEOUT_SEGUNDOS) { }

		public async Task<Salida> EjecutarServicio() {
			string entradaJson = "";
			if (entrada != null)
				entradaJson = JsonUtility.ToJson(entrada);
			string resultado = await EjecutarLlamadaWeb(entradaJson);
			return GenerarSalida(resultado);
		}

		private Salida GenerarSalida(string resultado) {
			try {
				return JsonUtility.FromJson<Salida>(resultado);
			}
			catch (Exception ex) {
				Debug.LogError($"[ServicioBounds] Error deserializando JSON de {url}: {ex.Message}\nJSON recibido: {resultado}");
				throw;
			}
		}

	}

}