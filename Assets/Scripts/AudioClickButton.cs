using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Mục đích sử dụng để tạo âm thanh khi bấm vào nút 
//Interface IPointerDownHandler, IPointerUpHandler
public class AudioClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    /// <summary>
    /// _compressClip: Lưu âm thanh khi bấm xuống
    /// _uncompress: Lưu âm thanh khi thả chuột không bấm nữa
    /// </summary>
    [SerializeField] private AudioClip _compressClip, _uncompressClip;
    //Lưu giữ về audio source: component dùng để phát âm thanh trong unity
    [SerializeField] private AudioSource _source;
    //Hàm xử lý sự kiện khi bấm chuột xuống một nút
    public void OnPointerDown(PointerEventData eventData)
    {
        //Gọi phương thức để chạy âm thanh _compressClip trong 1 khoảng khắc
        _source.PlayOneShot(_compressClip);
    }
    //Hàm xử lý sự kiện khi người dùng thả chuột 
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        ////Gọi phương thức để chạy âm thanh _uncompressClip trong 1 khoảng khắc
        _source.PlayOneShot(_uncompressClip);
    }
}
