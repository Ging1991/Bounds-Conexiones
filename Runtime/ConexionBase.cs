using System;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Bounds.Conexiones {

	public abstract class ConexionBase<Entrada, Salida> {

		private const string URL_BASE = "https://tcg-backend-prod.carloscaballeromorel.workers.dev";
		private const int TIMEOUT_SEGUNDOS = 15;

		private readonly string metodo;
		private readonly string servicio;

		public ConexionBase(string metodo, string servicio) {
			this.metodo = metodo;
			this.servicio = servicio;
		}

		public async Task<Salida> EjecutarAsync() {
			string urlCompleta = $"{URL_BASE}{servicio}";

			using (UnityWebRequest webRequest = new UnityWebRequest(urlCompleta, metodo)) {
				webRequest.downloadHandler = new DownloadHandlerBuffer();
				webRequest.timeout = TIMEOUT_SEGUNDOS;

				if (metodo == UnityWebRequest.kHttpVerbPOST) {
					string jsonBody = JsonUtility.ToJson(GenerarEntrada());
					byte[] rawData = Encoding.UTF8.GetBytes(jsonBody);

					webRequest.uploadHandler = new UploadHandlerRaw(rawData);
					webRequest.SetRequestHeader("Content-Type", "application/json");
				}

				webRequest.SetRequestHeader("Accept", "application/json");

				var tcs = new TaskCompletionSource<bool>();
				UnityWebRequestAsyncOperation asyncOp = webRequest.SendWebRequest();

				asyncOp.completed += _ => tcs.TrySetResult(true);

				await tcs.Task;

				if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
					webRequest.result == UnityWebRequest.Result.ProtocolError) {
					Debug.LogError($"[ConexionBase] Error en {servicio}: ({webRequest.responseCode}) {webRequest.error}\nRespuesta: {webRequest.downloadHandler.text}");
					throw new Exception($"Fallo en llamada a {servicio}: {webRequest.error}");
				}

				return GenerarRespuesta(webRequest.downloadHandler.text);
			}

		}

		private Salida GenerarRespuesta(string texto) {
			try {
				return JsonUtility.FromJson<Salida>(texto);
			}
			catch (Exception ex) {
				Debug.LogError($"[ConexionBase] Error deserializando JSON de {servicio}: {ex.Message}\nJSON recibido: {texto}");
				throw;
			}
		}

		protected abstract Entrada GenerarEntrada();

	}

}