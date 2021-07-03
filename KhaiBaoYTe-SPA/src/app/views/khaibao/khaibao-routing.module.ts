import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { KhaibaoComponent } from "./khaibao.component";
import { ThongbaoComponent } from "./thongbao/thongbao.component";

const routes: Routes = [
  {
    path: '',
    component: KhaibaoComponent,
    data: {
      title: "Khai báo thông tin cá nhân"
    }
  },
  {
    path: 'thongbao/:id',
    component: ThongbaoComponent,
    data: {
      title: 'Thông báo'
    }
  }
]
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class KhaibaoRoutingModule {}
