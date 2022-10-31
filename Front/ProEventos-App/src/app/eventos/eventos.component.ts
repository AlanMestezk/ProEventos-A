import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventosFiltrados: any=[];
  widthImg : number = 160;
  mostrarImg: boolean = true;
  private _filtroLista: string = '';

  public get filtroLista(): string{
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this._filtroLista) : this.eventos;
  }

  filtrarEventos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (      evento: {
        local: any; tema: string;
      }) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1

    )
  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
       this.getEventos();
  }

  alterarImagem(){
       this.mostrarImg = !this.mostrarImg;
  }

  public getEventos(): void {
      this.http.get('https://localhost:5001/api/Eventos').subscribe(
        response => {
          this.eventos = response;
          this.eventosFiltrados = this.eventos
        },

        error => console.log("Deu erro: " + error)
      );
  }

}
