import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PacienteInsertarComponent } from './paciente-insertar.component';

describe('PacienteInsertarComponent', () => {
  let component: PacienteInsertarComponent;
  let fixture: ComponentFixture<PacienteInsertarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PacienteInsertarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PacienteInsertarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
