using System;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Bounds.Conexiones {

	public abstract class ServicioWeb {

		protected readonly string url;
		private readonly string metodo;
		private readonly int timeout;

		public ServicioWeb(string metodo, string url, int timeout) {
			this.metodo = metodo;
			this.url = url;
			this.timeout = timeout;
		}

		protected async Task<string> EjecutarLlamadaWeb(string parametros) {

			using (UnityWebRequest webRequest = new UnityWebRequest(url, metodo)) {
				webRequest.downloadHandler = new DownloadHandlerBuffer();
				webRequest.timeout = timeout;

				if (metodo == UnityWebRequest.kHttpVerbPOST && parametros != "") {
					byte[] rawData = Encoding.UTF8.GetBytes(parametros);
					webRequest.uploadHandler = new UploadHandlerRaw(rawData);
					webRequest.SetRequestHeader("Content-Type", "application/json");
				}

				webRequest.SetRequestHeader("Accept", "application/json");

				var tcs = new TaskCompletionSource<bool>();
				UnityWebRequestAsyncOperation asyncOp = webRequest.SendWebRequest();

				asyncOp.completed += _ => tcs.TrySetResult(true);

				await tcs.Task;

				if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError) {
					Debug.LogError($"[Conexion] Error en {url}: ({webRequest.responseCode}) {webRequest.error}");
					Debug.LogError($"Respuesta: {webRequest.downloadHandler.text}");
					throw new Exception($"Fallo en llamada a {url}: {webRequest.error}");
				}

				return webRequest.downloadHandler.text;
			}

		}


	}

}