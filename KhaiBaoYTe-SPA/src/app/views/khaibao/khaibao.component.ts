import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Select2OptionData } from 'ng-select2';
import { fromEvent, Observable, of } from 'rxjs';
import { ThongtinService } from '../../_core/_services/thongtin.service';
import { debounceTime, distinctUntilChanged, map, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-khaibao',
  templateUrl: './khaibao.component.html',
  styleUrls: ['./khaibao.component.scss']
})
export class KhaibaoComponent implements OnInit {
  addThongTin: FormGroup;
  listTinh: Array<Select2OptionData>;
  listHuyenTT: Array<Select2OptionData>;
  listHuyenTamTru: Array<Select2OptionData>;
  listXaTT: Array<Select2OptionData>;
  listXaTamTru: Array<Select2OptionData>;
  listMQH: Array<Select2OptionData>;
  constructor(
    private fb: FormBuilder,
    private thongTinService: ThongtinService,
    private router: Router
    ) { }

  ngOnInit() {
    this.getDSTinh();
    this.initForm();
    this.getMqh();
    this.kiemTraNLD();
  }

  //Lấy danh sách tỉnh, thành phố
  getDSTinh() {
    this.thongTinService.getDSTinh().subscribe((res) => {
      this.listTinh = res.map((item) => {
        return { id: item.ma, text: item.ten };
      });
    });
  }

  // Lấy danh sách quận huyện theo mã tỉnh /tp
  getDSHuyen(e: any, type: number) {
    if(e.length > 0) {
      this.thongTinService.getDSHuyen(e).subscribe((res) => {
        let listHuyen = res.map((item) => {
          return { id: item.ma, text: item.ten };
        });
        type == 1 ? this.listHuyenTT = listHuyen : this.listHuyenTamTru = listHuyen;
      });
    }
  }

  // Lấy danh sách xã phương theo mã quận huyện
  getDSXa(e: any, type: number) {
    console.log("e: ",e);
    if(e.length > 0) {
      this.thongTinService.getDSXa(e).subscribe((res) => {
        let listXa = res.map((item) => {
          return { id: item.ma, text: item.ten };
        });
        type == 1 ? this.listXaTT = listXa : this.listXaTamTru = listXa;
      });
    }
  }

  // Lấy danh sách mối quan hệ.
  getMqh() {
    this.thongTinService.getMqh().subscribe((res) => {
      this.listMQH = res.map((item) => {
        return { id: `${item.ten}`, text: item.ten};
      });
    });
  }

  kiemTraNLD() {
    let changeInput = document.getElementById('soThe');
    let changeInput$ = fromEvent(changeInput, 'keyup');
    changeInput$.pipe(
      map((i:any) => i.currentTarget.value),
      debounceTime(1000),
      switchMap(data => {
        if(data !== '') {
          return this.thongTinService.getThongTin(data);
        } else {
          return of();
        }
      }),
      distinctUntilChanged()
    ).subscribe(res => {
      console.log(res);
      
    })
    // console.log(this.addThongTin.value.soThe);
    // if(e.target.value.length === 5){
    //   this.thongTinService.getThongTin(e.target.value).subscribe((res) => {
    //     if(res) {
    //       this.addThongTin.patchValue({
    //         hoTen: res.empName
    //       });
    //       (<HTMLInputElement>document.getElementById('hoTen')).disabled = true;
    //     }
    //   },
    //   (error) => {
    //     console.log(error);
    //   }
    //   )
    // } else {
    //   (<HTMLInputElement>document.getElementById('hoTen')).disabled = false;
    //   this.resetForm(1);
    // }
  }

  guiThongTin() {

    this.thongTinService.createThongTin(this.addThongTin.value).subscribe(() => {
      this.router.navigate(["/khaibao/thongbao/1"]);
    },
    (error) => {
      this.router.navigate(["/khaibao/thongbao/0"]);
    }
    )

  }


  // getTen(ma: string, type: number) {
  //   let model;
  //   switch(type){
  //     case 1:
  //       model = this.listTinh.filter(x => x.id == ma);
  //       break;
  //     case 2:
  //       model = this.listHuyenTT.filter(x => x.id == ma);
  //       break;
  //     case 3:
  //       model = this.listXaTT.filter(x => x.id == ma);
  //       break;
  //     case 4:
  //       model = this.listHuyenTamTru.filter(x => x.id == ma);
  //       break;
  //     case 5:
  //       model = this.listXaTamTru.filter(x => x.id == ma);
  //       break;
  //     case 6:
  //       model = this.listMQH.filter(x => x.id === ma);
  //       break;
  //     default:
  //       model = [];
  //       break;
  //   }

  //   return  model[0]?.text ?? '';
  // }

  initForm() {
    const regex = /[a-zA-Z]*/;
    this.addThongTin = this.fb.group({
      hoTen: ["", Validators.compose([Validators.required])],
      soThe: ["", Validators.compose([Validators.required])],
      sdtCaNhan: ["", Validators.compose([Validators.required, Validators.minLength(10)])],
      soCMND: ["", Validators.compose([Validators.required])],
      tinhThuongTru: ["", Validators.compose([Validators.required])],
      huyenThuongTru: ["", Validators.compose([Validators.required])],
      xaThuongTru: ["", Validators.compose([Validators.required])],
      soNhaThuongTru: ["", Validators.compose([Validators.required])],
      tinhTamTru: ["", Validators.compose([Validators.required])],
      huyenTamTru: ["", Validators.compose([Validators.required])],
      xaTamTru: ["", Validators.compose([Validators.required])],
      soNhaTamTru: ["", Validators.compose([Validators.required])],
      hoTenNguoiThan: ["", Validators.compose([Validators.required, Validators.pattern('[a-zA-Z ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ]*')])],
      mqhNguoiThan: ["", Validators.compose([Validators.required,Validators.minLength(1)])],
      sdtNguoiThan: ["", Validators.compose([Validators.required,Validators.minLength(10)])],
      loaiDT: ["Điện thoại thông minh", Validators.compose([Validators.required])],
    })
  }
  resetForm(option: number) {
    this.addThongTin.setValue({
      hoTen: "",
      soThe: (option === 0 ? "" : this.addThongTin.value.soThe),
      sdtCaNhan: "",
      soCMND: "",
      tinhThuongTru: "",
      huyenThuongTru: "",
      xaThuongTru: "",
      soNhaThuongTru: "",
      tinhTamTru: "",
      huyenTamTru: "",
      xaTamTru: "",
      soNhaTamTru: "",
      hoTenNguoiThan: "",
      mqhNguoiThan: "",
      sdtNguoiThan: "",
      loaiDT: "",
    })
   }
}
