import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { XuatexcelComponent } from './xuatexcel/xuatexcel.component';

const routes: Routes = [
  {
    path: '',
    component: XuatexcelComponent,
    data: {
      title: "Xuất Excel"
    }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class XuatexcelRoutingModule { }
