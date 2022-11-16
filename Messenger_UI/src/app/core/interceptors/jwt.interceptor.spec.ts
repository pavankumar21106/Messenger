import { TestBed } from '@angular/core/testing';

import { jwt } from './jwt.interceptor';

describe('jwt', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      jwt
      ]
  }));

  it('should be created', () => {
    const interceptor: jwt = TestBed.inject(jwt);
    expect(interceptor).toBeTruthy();
  });
});
