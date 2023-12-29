import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environment/environment';

@Injectable({
  providedIn: 'root'
})
export class PeliculasService {

  constructor(private http: HttpClient) { }

  peliculasPopulares(pageNumber: number) {
    return this.http.get(`${environment.baseURL}/Peliculas/PeliculasPopulares/${pageNumber}`);
  }

  buscarPelicula(nombre: string) {
    return this.http.get(`${environment.baseURL}/Peliculas/BuscarPeliculaPorNombre?nombrePelicula=${nombre}`);
  }

  peliculasPorUsuario(id: number) {
    return this.http.get(`${environment.baseURL}/Peliculas/PeliculasPorUsuario/${id}`);
  }

  buscarPeliculaPorId(id: number) {
    return this.http.get(`${environment.baseURL}/Peliculas/BuscarPeliculaPorId?idPelicula=${id}`);
  }

  guardarPelicula(pelicula: Object) {
    const url = `${environment.baseURL}/Peliculas/Guardar`
    return this.http.post(url, pelicula)
  }
}
