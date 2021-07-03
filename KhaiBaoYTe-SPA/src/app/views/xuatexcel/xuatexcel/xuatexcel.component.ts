import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { SnotifyPosition } from 'ng-snotify';
import { BsModalRef, BsModalService, ModalDirective } from 'ngx-bootstrap/modal';
import { AlertUtilityService } from '../../../_core/_services/alert-utility.service';
import { ThongtinService } from '../../../_core/_services/thongtin.service';

@Component({
  selector: 'app-xuatexcel',
  templateUrl: './xuatexcel.component.html',
  styleUrls: ['./xuatexcel.component.css']
})
export class XuatexcelComponent implements OnInit {
  modalRef: BsModalRef;
  pass: string = '';
  @ViewChild('template') template: TemplateRef<HTMLDivElement>;
  constructor(private thongTinService: ThongtinService,
              private modalService: BsModalService,
              private alertify: AlertUtilityService,
              private router: Router) { }

  ngOnInit() {
    
  }
  openModal() {
    this.modalRef = this.modalService.show(this.template, {
      backdrop: 'static'
    });
  }
  ngAfterViewInit() {
    this.openModal();
  }
  hidenModal() {
    let element1 = document.getElementsByClassName('modal-backdrop');
      let element2 = document.getElementsByClassName('modal');
      if(element1.length> 0) element1[0].remove();
      if(element2.length> 0) element2[0].remove();
  }
  enterPass() {
    if(this.pass === 'vuotquamuadich') {
      this.hidenModal();
    } else {
      this.alertify.error('Lỗi!', 'Mật khẩu không chính xác!',SnotifyPosition.rightTop);
    }
  }
  exportExcel() {
    this.thongTinService.exportExcel();
  }
  cancel() {
    this.router.navigate(['/khaibao']);
    this.hidenModal();
  }
}
