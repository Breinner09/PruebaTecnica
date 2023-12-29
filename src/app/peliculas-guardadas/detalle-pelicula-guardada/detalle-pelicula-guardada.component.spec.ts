import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetallePeliculaGuardadaComponent } from './detalle-pelicula-guardada.component';

describe('DetallePeliculaGuardadaComponent', () => {
  let component: DetallePeliculaGuardadaComponent;
  let fixture: ComponentFixture<DetallePeliculaGuardadaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DetallePeliculaGuardadaComponent]
    });
    fixture = TestBed.createComponent(DetallePeliculaGuardadaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
