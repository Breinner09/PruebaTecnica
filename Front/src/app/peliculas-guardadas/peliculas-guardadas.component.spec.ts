import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PeliculasGuardadasComponent } from './peliculas-guardadas.component';

describe('PeliculasGuardadasComponent', () => {
  let component: PeliculasGuardadasComponent;
  let fixture: ComponentFixture<PeliculasGuardadasComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PeliculasGuardadasComponent]
    });
    fixture = TestBed.createComponent(PeliculasGuardadasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
