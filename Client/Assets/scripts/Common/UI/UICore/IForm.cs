namespace SDK.Common
{
	/**
	 * @brief UI �ӿ�
	 */
	public interface IForm 
	{
        void init();
        void show();
        void exit();
        bool isVisible();
        UIFormID getFormID();
	}
}