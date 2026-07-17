using System;
using System.Collections.Generic;
using System.Text;
using StrategicBarber.Clases;

namespace StrategicBarber.Clases
{
    public static class Session
    {
       static int idUserSession;
       public static int idRolSession;
       public static string nombre;
       public static string apellido;
        //evento de notificacion
       public static event Action OnUsuarioCambiado;
        public static void IniciarSession(ClassUsuario user) {

            idRolSession = user.idRol;
            idUserSession = user.userid;
            nombre = user.Nombre;
            apellido = user.Apellido;

            // Disparamos el evento para notificar a los formularios
            OnUsuarioCambiado?.Invoke();
        }

    }

    
}
