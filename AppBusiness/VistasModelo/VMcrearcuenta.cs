using Firebase.Auth;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace AppBusiness.VistasModelo
{
    class VMcrearcuenta
    {
        public async void crearCuenta(String correo, string pass)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(Constantes.webapiFirebase));
            await authProvider.CreateUserWithEmailAndPasswordAsync(correo, pass);
        }

        public async void Validarcuenta(String correo, string pass)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(Constantes.webapiFirebase));
            var auth = await authProvider.SignInWithEmailAndPasswordAsync(correo, pass);
            /* Cuando el usuario se logea y genera un token */
            var contenido = await auth.GetFreshAuthAsync();
            var serializacion = JsonConvert.SerializeObject(contenido);
            Preferences.Set("MyFirebaseRefreshToken", serializacion);
        }
    }
}
