/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AlertUtilityService } from './alert-utility.service';

describe('Service: AlertUtility', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AlertUtilityService]
    });
  });

  it('should ...', inject([AlertUtilityService], (service: AlertUtilityService) => {
    expect(service).toBeTruthy();
  }));
});
