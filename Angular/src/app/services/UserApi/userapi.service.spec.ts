/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { UserapiService } from './userapi.service';

describe('Service: Userapi', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [UserapiService]
    });
  });

  it('should ...', inject([UserapiService], (service: UserapiService) => {
    expect(service).toBeTruthy();
  }));
});
