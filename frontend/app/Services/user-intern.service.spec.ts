import { TestBed } from '@angular/core/testing';

import { UserInternService } from './user-intern.service';

describe('UserInternService', () => {
  let service: UserInternService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserInternService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
