import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { response } from 'express';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {


  public eventos: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
       this.getEventos();
  }

  public getEventos(): void {
      this.http.get('https://localhost:5001/api/Eventos').subscribe(
        response => this.eventos = response,
        error => console.log("Deu erro: " + error)
      );
  }

}
