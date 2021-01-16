import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InstituicaoConsultaComponent } from './instituicao-consulta.component';

describe('InstituicaoConsultaComponent', () => {
  let component: InstituicaoConsultaComponent;
  let fixture: ComponentFixture<InstituicaoConsultaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InstituicaoConsultaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InstituicaoConsultaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
