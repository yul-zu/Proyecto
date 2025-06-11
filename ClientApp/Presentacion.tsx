import { useEffect, useState } from "react";

// Tipo de datos del equipo
type Equipo = {
  Id: string;
  Escuela: string;
  Carrera: string;
  Grupo: string;
  DatosSemestre: string;
  Proyecto: string;
  Integrante1: string;
  Integrante2: string;
  Fecha: string; // formato ISO como "2025-06-08T00:00:00Z"
};

// Función para formatear la fecha como "dd-mm-yy"
const formatearFecha = (fechaIso: string) => {
  const fecha = new Date(fechaIso);
  const dia = String(fecha.getDate()).padStart(2, "0");
  const mes = String(fecha.getMonth() + 1).padStart(2, "0");
  const anio = String(fecha.getFullYear()).slice(2); // últimos dos dígitos
  return `${dia}-${mes}-${anio}`;
};

const Presentacion = () => {
  const [equipo, setEquipo] = useState<Equipo>();

  // Cargar datos
  const cargarDatos = async () => {
    const resp = await fetch("/mi-proyecto/presentacion");
    if (resp.ok) {
      const datos = await resp.json();
      console.log(datos);
      setEquipo(datos);
    }
  };

  useEffect(() => {
    cargarDatos();
  }, []);

  return (
    <div className="container mt-5 text-center">
      <h1>{equipo?.Escuela}</h1>
      <h2>{equipo?.Carrera}</h2>
      <h3>{equipo?.DatosSemestre}</h3>
      <h3>{equipo?.Grupo}</h3> {/* Aquí ya debe venir como "4D" */}
      <h3 className="mt-4">Integrantes</h3>
      <h4>{equipo?.Integrante1}</h4>
      <h4>{equipo?.Integrante2}</h4>
      <h3 className="mt-5">Nombre del proyecto</h3>
      <h4>{equipo?.Proyecto}</h4>
      <p className="mt-3">{equipo?.Fecha ? formatearFecha(equipo.Fecha) : ''}</p>
    </div>
  );
};

export default Presentacion;

