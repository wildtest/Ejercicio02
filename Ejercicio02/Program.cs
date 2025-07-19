using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Ejercicio02.Program;

namespace Ejercicio02
{
	internal class Program
	{
		public abstract class Usuario
		{
			public int Id { get; set; }
			public string Nombre { get; set; }
			public string DNI { get; set; }

			public virtual void Notificacion()
			{
				Console.WriteLine($"Id: {Id}, Nombre: {Nombre}, DNI: {DNI}");
			}
		}
		public class Paciente : Usuario
		{
			private int NroHistoria { get; set; }

			public List<CitaMedica> CitasMedicas = new List<CitaMedica>();

			public Paciente(int _id, string _nombre, string _dni, int _nroHistoria)
			{
				Id = _id;
				Nombre = _nombre;
				DNI = _dni;
				NroHistoria = _nroHistoria;
			}

			public override void Notificacion()
			{

				Console.WriteLine($"Nuevo Paciente Registrado");
				base.Notificacion();
			}

			public override string ToString()
			{
				return ($"Id: {Id}, Nombre: {Nombre}, DNI: {DNI}, NroHistoria: {NroHistoria}");
			}

		}

		public class Hospital
		{
			public string Codigo { get; set; }
			public string Nombre { get; set; }
			public List<Especialidad> especialidades = new List<Especialidad>(); 
			public List<Paciente> pacientes = new List<Paciente>();
			public List<Doctor> doctores = new List<Doctor>();
			public List<Enfermera> enfermeras = new List<Enfermera>();

			public Hospital(string _codigo, string _nombre)
			{
				Codigo = _codigo;
				Nombre = _nombre;
			}

			public void AgregarEspecialidad(Especialidad especialidad) => especialidades.Add(especialidad);
			public void AgregarPaciente(Paciente paciente) => pacientes.Add(paciente);
			public void AgregarDoctor(Doctor doctor) => doctores.Add(doctor);
			public void AgregarEnfermera(Enfermera enfermera) => enfermeras.Add(enfermera);

			public List<Especialidad> ObtenerEspecialidades() => especialidades;

			public List<Paciente> ObtenerPacientes() => pacientes;
			public List<Doctor> ObtenerDoctores() => doctores;
			public List<Enfermera> ObtenerEnfermeras() => enfermeras;

			public override string ToString()
			{
				return ($"Código: {Codigo}, Nombre: {Nombre}");
			}
		}

		public class CitaMedica
		{
			public Especialidad Especialidad { get; set; }
			public Doctor Doctor { get; set; }
			public string Horario { get; set; }
			public Hospital Hospital { get; set; }
			public Paciente Paciente { get; set; }

			public CitaMedica(Especialidad especialidad, Doctor doctor, Hospital hospital, string horario, Paciente paciente)
			{
				Especialidad = especialidad;
				Doctor = doctor;
				Hospital = hospital;
				Horario = horario;
				Paciente = paciente;
			}

			public override string ToString()
			{
				return ($"Paciente: {Paciente.Nombre}, Especialidad: {Especialidad.Nombre}, Doctor: {Doctor.Nombre}, Hospital: {Hospital.Nombre}, Horario: {Horario}");
			}

			public void MostrarDatosCita()
			{
				Console.WriteLine("\n------------------------------");
				Console.WriteLine($"Paciente: {Paciente.Nombre}");
				Console.WriteLine($"Hospital: {Hospital.Nombre}");
				Console.WriteLine($"Especialidad: {Especialidad.Nombre}");
				Console.WriteLine($"Doctor: {Doctor.Nombre}");
				Console.WriteLine($"Horario: {Horario}");
			}
		}

		public class Doctor : Usuario
		{
			public Especialidad Especialidad { get; set; }

			public Doctor(int _id, string _nombre, string _dni, Especialidad _especialidad)
			{
				Id = _id;
				Nombre = _nombre;
				DNI = _dni;
				Especialidad = _especialidad;
			}

			public override void Notificacion()
			{

				Console.WriteLine($"Nuevo Doctor Registrado");
				base.Notificacion();
			}

			public override string ToString()
			{
				return ($"Id: {Id}, Nombre: {Nombre}, DNI: {DNI}, Especialidad: {Especialidad.Nombre}");
			}
		}

		public class Enfermera : Usuario
		{
			public string NumeroLicencia { get; set; }
			public string Turno { get; set; }
			public Especialidad Especialidad { get; set; }
			public Enfermera(int _id, string _nombre, string _dni, string _numeroLicencia, string _turno, Especialidad _especialidad)
			{
				Id = _id;
				Nombre = _nombre;
				DNI = _dni;
				NumeroLicencia = _numeroLicencia;
				Turno = _turno;
				Especialidad = _especialidad;
			}

			public override void Notificacion()
			{

				Console.WriteLine($"Nueva Enfermera Registrada");
				base.Notificacion();
			}

			public override string ToString()
			{
				return ($"Id: {Id}, Nombre: {Nombre}, DNI: {DNI}, Numero Licencia: {NumeroLicencia}, Turno: {Turno}, Especialidad: {Especialidad.Nombre}");
			}
		}

		public class Especialidad
		{
			public int Id { get; set; }
			public string Nombre { get; set; }

			public Especialidad(int id, string nombre)
			{
				Id = id;
				Nombre = nombre;
			}

			public override string ToString()
			{
				return ($"Id: {Id}, Nombre: {Nombre}");
			}

		}

		public static void Main(string[] args)
		{
			List<CitaMedica> citasMedicas = new List<CitaMedica>();
			List<Paciente> pacientes = new List<Paciente>
			{
				new Paciente(0, "Juan Medina", "9898", 6534),
				new Paciente(1, "Julio Ramirez", "8787", 6534),
				new Paciente(2, "Marco Marquez", "7676", 6534),
				new Paciente(3, "Angel García", "6565", 6534)
			};

			List<Especialidad> especialidades = new List<Especialidad>
			{
				new Especialidad(0, "Odontología"),
				new Especialidad(1, "Cardiología"),
				new Especialidad(2, "Oftalmología"),
				new Especialidad(3, "Pediatría")
			};

			List<Doctor> doctores = new List<Doctor>
			{
				new Doctor(0, "Dr. Luis Martinez", "5454", especialidades[0]),
				new Doctor(1, "Dr. Miguel Rodriguez", "6565", especialidades[1]),
				new Doctor(2, "Dr. Jose Perez", "4343", especialidades[2]),
				new Doctor(3, "Dr. Dante Sanchez", "3232", especialidades[3])
			};

			List<Enfermera> enfermeras = new List<Enfermera>()
			{
				new Enfermera(0, "Maria Ramirez", "9090","111", "Mañana", especialidades[0]),
				new Enfermera(1, "Carla Miranda", "8080", "222", "Tarde", especialidades[1]),
				new Enfermera(2, "Wendy Rodriguez", "7070", "333", "Noche", especialidades[2]),
				new Enfermera(3, "Johana Gutierrez", "6060","444", "Tarde", especialidades[3])
			};

			List<Hospital> hospitales = new List<Hospital>
			{
				new Hospital("001", "Hospital Regional"),
				new Hospital("002", "Hospital Jesus de Nazareth"),
				new Hospital("003", "Hospital Santa Rosa de Lima"),
				new Hospital("004", "Hospital Simo Bolivar")
			};

			hospitales[0].AgregarEspecialidad(especialidades[0]);
			hospitales[0].AgregarEspecialidad(especialidades[1]);
			hospitales[0].AgregarEspecialidad(especialidades[2]);
			hospitales[0].AgregarEspecialidad(especialidades[3]);
			hospitales[0].AgregarDoctor(doctores[0]);
			hospitales[0].AgregarDoctor(doctores[1]);
			hospitales[0].AgregarDoctor(doctores[2]);
			hospitales[0].AgregarDoctor(doctores[3]);
			hospitales[0].AgregarEnfermera(enfermeras[0]);
			hospitales[0].AgregarEnfermera(enfermeras[1]);
			hospitales[0].AgregarEnfermera(enfermeras[2]);
			hospitales[0].AgregarEnfermera(enfermeras[3]);

			hospitales[1].AgregarEspecialidad(especialidades[1]);
			hospitales[1].AgregarEspecialidad(especialidades[2]);
			hospitales[1].AgregarDoctor(doctores[1]);
			hospitales[1].AgregarDoctor(doctores[2]);

			hospitales[2].AgregarEspecialidad(especialidades[2]);
			hospitales[2].AgregarEspecialidad(especialidades[3]);
			hospitales[2].AgregarDoctor(doctores[2]);
			hospitales[2].AgregarDoctor(doctores[3]);
			hospitales[2].AgregarEnfermera(enfermeras[2]);
			hospitales[2].AgregarEnfermera(enfermeras[3]);

			bool salirSistema = false;
			do
			{
				Console.WriteLine("MENÚ PRINCIPAL");
				Console.WriteLine("==============");
				Console.WriteLine("1. Registrar Paciente");
				Console.WriteLine("2. Registrar Doctor");
				Console.WriteLine("3. Registrar Enfermera");
				Console.WriteLine("4. Registrar Cita Médica");
				Console.WriteLine("5. Mostrar Citas Médicas");
				Console.WriteLine("6. Mostrar Hospitales");
				Console.WriteLine("7. Mostrar Especialidades");
				Console.WriteLine("8. Mostrar Doctores");
				Console.WriteLine("9. Mostrar Enfermeras");
				Console.WriteLine("10. Salir");
				Console.Write("Ingrese Una Opción: ");
				int opcion = int.Parse(Console.ReadLine());
				if (opcion <= 0 || opcion > 10)
				{
					Console.WriteLine("Opción Incorrecta, Seleccione Nuevamente!");
				}
				else
				{
					switch (opcion)
					{
						case 1:
							RegistrarPaciente(pacientes);
							break;
						case 2:
							RegistrarDoctor(doctores, especialidades);
							break;
						case 3:
							RegistrarEnfermera(enfermeras, especialidades);
							break;
						case 4:
							RegistrarCitaMedica(citasMedicas, hospitales, especialidades, doctores, pacientes);
							break;
						case 5:
							MostrarCitasMedicas(citasMedicas);
							break;
						case 6:
							MostrarHospitales(hospitales);
							break;
						case 7:
							MostrarEspecialidades(hospitales);
							break;
						case 8:
							MostrarDoctores(hospitales);
							break;
						case 9:
							MostrarEnfermeras(hospitales);
							break;
						case 10:
							Console.WriteLine("Saliendo del Sistema...");
							salirSistema = true;
							break;

					}
				}
				
			} while (!salirSistema);
			
			
		}

		public static void RegistrarPaciente(List<Paciente> pacientes)
		{
			Console.WriteLine("Ingrese Datos de Paciente");
			Console.WriteLine("-------------------------");
			Console.Write("Nombre: ");
			string nombre = Console.ReadLine();
			Console.Write("DNI: ");
			string dni = Console.ReadLine();
			Console.Write("Nro Historia: ");
			int nroHistoria = int.Parse(Console.ReadLine());
			Paciente paciente = new Paciente(pacientes.Count, nombre, dni, nroHistoria);
			pacientes.Add(paciente);
			paciente.Notificacion();

		}

		public static void RegistrarDoctor(List<Doctor> doctores, List<Especialidad> especialidades)
		{
			Console.WriteLine("Ingrese Datos del Doctor");
			Console.WriteLine("-------------------------");
			Console.Write("Nombre: ");
			string nombre = Console.ReadLine();
			Console.Write("DNI: ");
			string dni = Console.ReadLine();
			Console.WriteLine("Seleccione una Especialidad");
			foreach (Especialidad especialidad in especialidades) 
			{ 
				especialidad.ToString();
			}
			Console.Write("Ingrese ID: ");
			int idEspecialidad = int.Parse(Console.ReadLine());
			if(idEspecialidad < 0 || idEspecialidad >= especialidades.Count)
			{
				Console.WriteLine("ID de especialidad Incorrecta");
			}
			else
			{
				Doctor doctor = new Doctor(doctores.Count, nombre, dni, especialidades[idEspecialidad]);
				doctores.Add(doctor);
				doctor.Notificacion();
			}
			
		}

		public static void RegistrarEnfermera(List<Enfermera> enfermeras, List<Especialidad> especialidades)
		{
			Console.WriteLine("Ingrese Datos de Enfermera");
			Console.WriteLine("-------------------------");
			Console.Write("Nombre: ");
			string nombre = Console.ReadLine();
			Console.Write("DNI: ");
			string dni = Console.ReadLine();
			Console.Write("Numero Licencia: ");
			string numeroLicencia = Console.ReadLine();
			Console.Write("Turno: ");
			string turno = Console.ReadLine();
			Console.WriteLine("Seleccione una Especialidad");
			foreach (Especialidad especialidad in especialidades)
			{
				especialidad.ToString();
			}
			Console.Write("Ingrese ID: ");
			int idEspecialidad = int.Parse(Console.ReadLine());
			if (idEspecialidad < 0 || idEspecialidad >= especialidades.Count)
			{
				Console.WriteLine("ID de especialidad Incorrecta");
			}
			else
			{
				Enfermera enfermera = new Enfermera(enfermeras.Count, nombre, dni, numeroLicencia, turno, especialidades[idEspecialidad]);
				enfermeras.Add(enfermera);
				enfermera.Notificacion();
			}

		}

		public static void RegistrarCitaMedica(List<CitaMedica> citasMedicas, List<Hospital> hospitales, List<Especialidad> especialidades, List<Doctor> doctores, List<Paciente> pacientes)
		{
			Console.WriteLine("Ingrese Datos de Cita Médica");
			Console.WriteLine("----------------------------");
			Console.Write("Ingrese DNI Paciente: ");
			string dni = Console.ReadLine();
			Paciente pacienteSeleccionado = pacientes.FirstOrDefault(p => p.DNI == dni);
			if (pacienteSeleccionado == null)
			{
				Console.WriteLine("Paciente no registrado");
			}
			else
			{
				string registrarCita = "N";
				do
				{
					Console.WriteLine("Seleccione Un Hospital Disponible");
					foreach (Hospital hospital in hospitales)
					{
						Console.WriteLine(hospital.ToString());
					}
					Console.Write("Ingrese Código de Hospital: ");
					string codigoHospital = Console.ReadLine();
					Hospital hospitalSeleccionado = hospitales.FirstOrDefault(h => h.Codigo == codigoHospital);
					if (hospitalSeleccionado != null)
					{
						string ingresarEspecialidad = "N";
						do
						{
							Console.Write("Ingrese nombre de Especialidad: ");
							string nombreEspecialidad = Console.ReadLine();
							Especialidad especialidadSeleccionada = especialidades.FirstOrDefault(e => e.Nombre.Equals(nombreEspecialidad) && hospitalSeleccionado.ObtenerEspecialidades().Contains(e));
							if (especialidadSeleccionada != null)
							{
								
								string ingresarDoctor = "N";
								do
								{
									Console.Write("Ingrese DNI del Doctor: ");
									string dniDoctor = Console.ReadLine();
									Doctor doctorSeleccionado = doctores.FirstOrDefault(d =>
										d.DNI.Equals(dniDoctor) &&
										d.Especialidad == especialidadSeleccionada &&
										hospitalSeleccionado.ObtenerDoctores().Contains(d));

									if (doctorSeleccionado != null)
									{
										Console.Write("Ingrese Horario: ");
										string horario = Console.ReadLine();
										CitaMedica citaMedica = new CitaMedica(especialidadSeleccionada, doctorSeleccionado, hospitalSeleccionado, horario, pacienteSeleccionado);
										citasMedicas.Add(citaMedica);
										Console.WriteLine("Cita Médica Registrada Correctamente!");
										ingresarDoctor = "N";
									}
									else
									{
										Console.WriteLine($"El Doctor no Pertenece a la Especialidad de {especialidadSeleccionada.Nombre}");
										Console.WriteLine("Ingrese un Doctor de la Lista");
										foreach (var doctor in hospitalSeleccionado.ObtenerDoctores())
										{
											Console.WriteLine(doctor.ToString());
										}
										Console.Write("\nDesea Intentar de Nuevo? S/N: ");
										ingresarDoctor = Console.ReadLine();

									}
								} while (ingresarDoctor.ToUpper().Equals("S"));
								ingresarEspecialidad = "N";
							}
							else
							{
								Console.WriteLine($"Epecialidad No Disponible en {hospitalSeleccionado.Nombre}");
								Console.Write("Desea Ingresar Otra Especialidad? N/S: ");
								ingresarEspecialidad = Console.ReadLine();
							}
						} while (ingresarEspecialidad.ToUpper().Equals("S"));
						

					}
					else{
						Console.WriteLine("Hospital No Registrado");
					}

					Console.Write("Registrar Nueva Cita Médica? S/N: ");
					registrarCita = Console.ReadLine();

				} while (registrarCita.ToUpper().Equals("S"));
				
	
			}
			
		}

		public static void MostrarCitasMedicas(List<CitaMedica> citasMedicas)
		{
			Console.WriteLine("\nMOSTRAR CITAS MÉDICAS");
			Console.WriteLine("========================");

			Console.Write("Ingrese DNI Paciente: ");
			string dniConsulta = Console.ReadLine();
			var citasPaciente = citasMedicas.Where(c => c.Paciente.DNI == dniConsulta).ToList();

			if (!citasPaciente.Any())
			{
				Console.WriteLine("No se encontraron citas para el paciente seleccionado");
			}
			else
			{
				foreach (var cita in citasPaciente)
				{
					cita.MostrarDatosCita();
				}
			}
			Console.Write("\n");
		}

		public static void MostrarDoctores(List<Hospital> hospitales)
		{
			Console.WriteLine("Mostrar Doctores");
			Console.WriteLine("----------------");
			Console.Write("Código Hospital: ");
			string codigoHospital = Console.ReadLine();
			Hospital hospital = hospitales.FirstOrDefault(h => h.Codigo == codigoHospital);
			if (hospital != null) 
			{
				foreach (Doctor doctor in hospital.ObtenerDoctores())
				{
					Console.WriteLine(doctor.ToString());
				}
			}
			else
			{
				Console.WriteLine("Código de Hospital no Existe");
			}

		}

		public static void MostrarEnfermeras(List<Hospital> hospitales)
		{
			Console.WriteLine("Mostrar Enfermeras");
			Console.WriteLine("----------------");
			Console.Write("Código Hospital: ");
			string codigoHospital = Console.ReadLine();
			Hospital hospital = hospitales.FirstOrDefault(h => h.Codigo == codigoHospital);
			if (hospital != null)
			{
				foreach (Enfermera enfermera in hospital.ObtenerEnfermeras())
				{
					Console.WriteLine(enfermera.ToString());
				}
			}
			else
			{
				Console.WriteLine("Código de Hospital no Existe");
			}
		}

		public static void MostrarEspecialidades(List<Hospital> hospitales)
		{
			Console.WriteLine("Mostrar Especialidades");
			Console.WriteLine("----------------");
			Console.Write("Código Hospital: ");
			string codigoHospital = Console.ReadLine();
			Hospital hospital = hospitales.FirstOrDefault(h => h.Codigo == codigoHospital);
			if (hospital != null)
			{
				foreach (Especialidad especialidad in hospital.ObtenerEspecialidades())
				{
					Console.WriteLine(especialidad.ToString());
				}
			}
			else
			{
				Console.WriteLine("Código de Hospital no Existe");
			}
		}

		public static void MostrarHospitales(List<Hospital> hospitales)
		{
			Console.WriteLine("Mostrar Hospitales");
			Console.WriteLine("----------------");

			if (hospitales.Any())
			{
				foreach (Hospital hospital in hospitales)
				{
					Console.WriteLine(hospital.ToString());
				}
			}
			else
			{
				Console.WriteLine("No Existen Hospitales Registrados");
			}
		}
	}
}
