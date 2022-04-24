import { Injectable } from '@angular/core';
import { Reserva } from '../interfaces/reserva';

@Injectable({
  providedIn: 'root'
})
export class ReservaService {

  listReservas: Reserva[] = [
    {usuario: "ArmandoCor15", nombre: 'Armando', apellido: "Cortes", sexo: 'Masculino'},
    {usuario: "Juan134", nombre: 'Juan', apellido: "Hernandez", sexo: 'Masculino'},
    {usuario: "karoM12", nombre: 'Karolina', apellido: "Cortes", sexo: 'Femenino'},
    {usuario: "Adriana322", nombre: 'Adriana', apellido: "Gonzalez", sexo: 'Femenino'},
    {usuario: "Carlos322", nombre: 'Carlos', apellido: "Garita", sexo: 'Masculino'},
    {usuario: "Veronica2021", nombre: 'Veronica', apellido: "Vindas", sexo: 'Femenino'},
    {usuario: "NataliaGa23", nombre: 'Natalia', apellido: "Arroyo", sexo: 'Femenino'}
  ];

  constructor() {}

  getReserva(){
    return this.listReservas.slice(); //Retorna una copia del listado de usuarios
  }

  eliminarReserva(index: number){
    this.listReservas.splice(index, 1);
  }

  agregarReserva(reserva: Reserva){
    this.listReservas.unshift(reserva)
    //unshift agrega el usuario al inicio de el array
  }

  getEditarReservas(index: number){
    return this.listReservas[index];
  }

  updateReserva(reserva: Reserva, index: number){
    this.listReservas[index] = {usuario: "", nombre: '', apellido: "", sexo: ''}
    this.listReservas[index] = reserva;
  }
}