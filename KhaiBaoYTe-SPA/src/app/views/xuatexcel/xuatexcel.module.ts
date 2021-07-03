import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgxSpinnerModule } from 'ngx-spinner';

import { XuatexcelRoutingModule } from './xuatexcel-routing.module';
import { ModalModule } from 'ngx-bootstrap/modal';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { XuatexcelComponent } from './xuatexcel/xuatexcel.component';

@NgModule({
  declarations: [
    XuatexcelComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgxSpinnerModule,
    ModalModule.forRoot(),
    XuatexcelRoutingModule
  ],
  schemas: [
    NO_ERRORS_SCHEMA
  ]
})
export class XuatexcelModule { }
