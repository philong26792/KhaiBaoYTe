/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { XuatexcelComponent } from './xuatexcel.component';

describe('XuatexcelComponent', () => {
  let component: XuatexcelComponent;
  let fixture: ComponentFixture<XuatexcelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ XuatexcelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(XuatexcelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
