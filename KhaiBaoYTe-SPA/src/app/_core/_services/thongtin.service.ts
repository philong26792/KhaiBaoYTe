import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { environment } from '../../../environments/environment';
import { ThongTin } from '../_models/thong-tin';
@Injectable({
  providedIn: 'root'
})
export class ThongtinService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient, private spinnerService: NgxSpinnerService) { }

  getDSTinh() {
    return this.http.get<any>(this.baseUrl + 'KhaiBao/DanhSachTinh', {});
  }

  getDSHuyen(maTP: string) {
    return this.http.get<any>(this.baseUrl + 'KhaiBao/DanhSachHuyenTheoTinh/' + maTP, {});
  }

  getMqh() {
    return this.http.get<any>(this.baseUrl + 'KhaiBao/DanhSachMqh', {});
  }
  getDSXa(maQH: string) {
    return this.http.get<any>(this.baseUrl + 'KhaiBao/DanhSachXaTheoHuyen/' + maQH, {});
  }

  getThongTin(soThe: string) {
    return this.http.get<any>(this.baseUrl + 'KhaiBao/GetInfoUser/' + soThe, {});
  }

  createThongTin(thongTin: ThongTin) {
    return this.http.post(this.baseUrl + 'KhaiBao/ThemThongTin', thongTin, {});
  }
  exportExcel() {
    this.spinnerService.show();
    return this.http.get(this.baseUrl + 'KhaiBao/XuatExcel/', {responseType: 'blob'}).subscribe(
      (result: Blob) => {
        if (result.type !== 'application/xlsx') {
          alert(result.type);
        }
        const blob = new Blob([result]);
        const url = window.URL.createObjectURL(blob);
        const link = document.createElement('a');
        const currentTime = new Date();
        const filename = 'Excel_KhaiBaoYTe_Report' + currentTime.getFullYear().toString() +
          (currentTime.getMonth() + 1) + currentTime.getDate() +
          currentTime.toLocaleTimeString().replace(/[ ]|[,]|[:]/g, '').trim() + '.xlsx';
        link.href = url;
        link.setAttribute('download', filename);
        document.body.appendChild(link);
        link.click();
        this.spinnerService.hide();
      }
    );
  }
}
