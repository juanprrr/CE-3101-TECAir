import { Component, OnInit } from '@angular/core';
import { Suitcase } from 'src/app/Models/suitcase';
import { SuitcaseService } from 'src/app/Services/suitcase.service';

@Component({
  selector: 'app-baggage-asg',
  templateUrl: './baggage-asg.component.html',
  styleUrls: ['./baggage-asg.component.css']
})
export class BaggageAsgComponent implements OnInit {
  suitcase = new Suitcase

  constructor(private service:SuitcaseService) { }

  ngOnInit(): void {
  }

  addSuitcase(newSuitcase:Suitcase){
    this.service.insertSuitcase(newSuitcase).subscribe(()=>{
      window.location.reload()
      alert("La maleta se registró correctamente!")
    },()=>alert("No se pudo registrar la maleta, por favor intente de nuevo!"))
  }

}
