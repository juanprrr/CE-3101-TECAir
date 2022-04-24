import { Component, OnInit } from '@angular/core';

export interface PeriodicElement {
  Vuelo: string;
  position: number;
  Salida: string;
  Llegada: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {position: 1, Vuelo: 'Los Angeles', Salida: 'Juan Santa Maria', Llegada: 'Los Angeles'},
  {position: 2, Vuelo: 'Califoria', Salida: 'Juan Santa Maria', Llegada: 'California'},
  {position: 3, Vuelo: 'Otawa', Salida: 'Juan Santa Maria', Llegada: 'Otawa'},
  {position: 4, Vuelo: 'Kiev', Salida: 'Juan Santa Maria', Llegada: 'Kiev'},
  {position: 5, Vuelo: 'London', Salida: 'Juan Santa Maria', Llegada: 'London'},
  {position: 6, Vuelo: 'Montevideo', Salida: 'Juan Santa Maria', Llegada: 'Montevideo'},
  {position: 7, Vuelo: 'Madrid', Salida: 'Juan Santa Maria', Llegada: 'Madrid'},
];

@Component({
  selector: 'app-vuelos',
  templateUrl: './vuelos.component.html',
  styleUrls: ['./vuelos.component.css']
})
export class VuelosComponent implements OnInit {

  displayedColumns: string[] = ['position', 'Vuelo', 'Salida', 'Llegada'];
  dataSource = ELEMENT_DATA;
  constructor() { }

  ngOnInit(): void {
  }

}

