﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Shared
{
    public class Usuarios
    {
        [Key]

        public int UsuarioId { get; set; }

        [Required (ErrorMessage ="Las Credenciales son Incorrectas")]
        public string Correo { get; set; }

		[Required(ErrorMessage = "Las Credenciales son Incorrectas")]
		public string Clave { get; set; }
	}
}
