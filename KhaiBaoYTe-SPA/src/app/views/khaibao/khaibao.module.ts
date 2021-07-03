import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgSelect2Module } from "ng-select2";
import { NgxMaskModule } from 'ngx-mask'

import { KhaibaoRoutingModule } from "./khaibao-routing.module";
import { KhaibaoComponent } from "./khaibao.component";
import { ThongbaoComponent } from "./thongbao/thongbao.component";

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgSelect2Module,
    NgxMaskModule.forRoot(),
    KhaibaoRoutingModule
  ],
  declarations: [
    KhaibaoComponent,
    ThongbaoComponent
  ]
})
export class KhaibaoModule {
}
