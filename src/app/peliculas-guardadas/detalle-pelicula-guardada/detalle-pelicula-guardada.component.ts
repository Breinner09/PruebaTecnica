import { Component, OnInit , Inject} from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Pelicula } from 'src/app/Interfaces/pelicula';
import { PeliculasService } from 'src/app/services/peliculas.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-detalle-pelicula-guardada',
  templateUrl: './detalle-pelicula-guardada.component.html',
  styleUrls: ['./detalle-pelicula-guardada.component.scss']
})
export class DetallePeliculaGuardadaComponent implements OnInit{

  constructor(private _peliculasService: PeliculasService,
    private dialogRef: MatDialogRef<DetallePeliculaGuardadaComponent>,
    @Inject(MAT_DIALOG_DATA) public dataPelicula: any
  ) { }
  calificacion: number = 1;
  estrellas: any = Array(5)

  ngOnInit(): void {
      if (this.dataPelicula) {
        this.calificacion = this.dataPelicula.calificacion        
      }
  }

  sliderChange(event: any){
    this.calificacion = event.target.value;
    console.log(this.calificacion);
    
  }
}
