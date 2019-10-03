import { AviationAppTemplatePage } from './app.po';

describe('AviationApp App', function() {
  let page: AviationAppTemplatePage;

  beforeEach(() => {
    page = new AviationAppTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
