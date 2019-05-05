import { AppPage } from './app.po';

describe('Gamification App', () => {
    let page: AppPage;

    beforeEach(() => {
        page = new AppPage();
    });

    it('should display application title: Gamification', () => {
        page.navigateTo();
        expect(page.getAppTitle()).toEqual('Gamification');
    });
});
