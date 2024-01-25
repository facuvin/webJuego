﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Logica
{
    public interface iLogicaJugada
    {
        void AgregarJugada(Jugada J);

        List<Jugada> ListarJugadas();
    }
}
